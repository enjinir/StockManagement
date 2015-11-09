using DatabaseHelper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    public static class DBHelper
    {
        private static SqlConnection _connection;
        public static User CurrentUser { get; set; }

        public static bool IsConnected 
        { 
            get 
            {
                if (_connection != null)
                {
                    return _connection.State.Equals(ConnectionState.Open);
                }
                else
                {
                    return false;
                }
            } 
        }
        public static ConnectionState State
        {
            get 
            {
                return _connection.State;
            }
        }

        public static void Connect(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public static void Disconnect()
        {
            if (IsConnected)
            {
                _connection.Close();
            }
        }

        public static bool CheckLogin(string username, string password)
        {
            // Create sql command
            string query = "SELECT 1 FROM dbo.[User] WHERE [Username] = @username AND [Password] = @password";
            SqlCommand command = new SqlCommand(query, _connection);

            // Add paramters
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@password", password));

            var result = command.ExecuteScalar();
            
            if(result != null) 
            {
                CurrentUser = GetUsers().Where(u => u.Username == username).FirstOrDefault();
                LogOperation(Guid.Empty, CurrentUser.FullName + " logged in.", "Login");
            }

            return result != null;
        }

        public static bool CheckAdminLogin(string username, string password)
        {
            // Create sql command
            string query = "SELECT 1 FROM dbo.[User] WHERE [Username] = @username AND [Password] = @password AND [IsAdmin]=1";
            SqlCommand command = new SqlCommand(query, _connection);

            // Add paramters
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@password", password));

            var result = command.ExecuteScalar();

            if (result != null)
            {
                CurrentUser = GetUsers().Where(u => u.Username == username).FirstOrDefault();
                LogOperation(Guid.Empty, CurrentUser.FullName + " logged in.", "Login");
            }

            return result != null;
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            string query = "SELECT p.ProductId, p.Name, p.OwnerId, u.FullName "
                         + "FROM dbo.[Product] p "
                         + "INNER JOIN dbo.[User] u ON u.UserId = p.OwnerId "
                         + "WHERE p.OwnerId = @ownerid";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@ownerid", CurrentUser.UserId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductId = reader.GetGuid(0);
                    p.Name = reader.GetString(1);
                    p.OwnerId = reader.GetGuid(2);
                    p.OwnerName = reader.GetString(3);

                    products.Add(p);
                }
            }

            return products;
        }

        public static List<Product> GetProducts(Guid userId)
        {
            List<Product> products = new List<Product>();

            string query = "SELECT p.ProductId, p.Name, p.OwnerId, u.FullName "
                         + "FROM dbo.[Product] p "
                         + "INNER JOIN dbo.[User] u ON u.UserId = p.OwnerId "
                         + "WHERE p.OwnerId = @ownerid";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@ownerid", userId);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductId = reader.GetGuid(0);
                    p.Name = reader.GetString(1);
                    p.OwnerId = reader.GetGuid(2);
                    p.OwnerName = reader.GetString(3);

                    products.Add(p);
                }
            }

            return products;
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            string query = "SELECT UserId, FullName, Username, Email, RegistrationDate, IsAdmin FROM dbo.[User]";

            SqlCommand command = new SqlCommand(query, _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User u = new User() 
                    {
                        UserId = reader.GetGuid(0),
                        FullName = reader.GetString(1),
                        Username = reader.GetString(2),
                        Email = reader.GetString(3),
                        RegistrationDate = reader.GetDateTime(4),
                        IsAdmin = reader.GetBoolean(5)
                    };

                    users.Add(u);
                }
            }

            return users;
        }

        public static StockInfo GetStockInfo(Product selectedProduct)
        {
            StockInfo stockInfo = null;

            string query = "SELECT TOP 1 ProductId, Count FROM dbo.Stock WHERE ProductId = @ProductId";
            
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.Add(new SqlParameter("@ProductId", selectedProduct.ProductId));

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    stockInfo = new StockInfo()
                    {
                        ProductId = reader.GetGuid(0),
                        Count = reader.GetInt32(1)
                    };
                }
            }

            return stockInfo;
        }

        public static bool UpdateStock(Product product, int count)
        {
            // TODO: Add unit price 

            string query = "";
            StockInfo stockInfo = GetStockInfo(product);
            if (stockInfo != null)
            {
                query += "Update Stock set Count=@count from Stock Where ProductId=@productid";
            }
            else
            {
                query += "Insert Into Stock values (@productid,@count,5)";
            }

            SqlCommand command = new SqlCommand(query,_connection);
            command.Parameters.Add(new SqlParameter("@productid", product.ProductId));
            command.Parameters.Add(new SqlParameter("@count", count));
            int rows = command.ExecuteNonQuery();
            
            if(rows > 0) 
            {
                LogUpdate(product.ProductId, "Stock updated from " + ((stockInfo != null) ? stockInfo.Count : 0) +  " to " + count);
            }

            return rows > 0;

        }

        public static bool CreateProduct(Product product)
        {
            string query="";
            if (!ProductExists(product))
            {
                query = "insert into product (Name,OwnerId) output INSERTED.ProductId values (@name , @ownerid)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@ownerid", product.OwnerId);
                var productId = command.ExecuteScalar();

                if (productId != null)
                {
                    LogCreate((Guid)productId, "Created product '" + product.Name + "'");
                }

                return productId != null;
            }
            else
                return false;
        }

        public static bool ProductExists(Product product)
        {
            string query = "Select 1 from Product where name=@name";
            SqlCommand command = new SqlCommand(query,_connection);
            command.Parameters.AddWithValue("@name", product.Name);
            var result = command.ExecuteScalar();
            return result != null;
        }

        public static bool UpdateProduct(Product product)
        {
            bool updated = false;

            string query = "update product set Name = @name, OwnerId=@ownerid "
                            + "output deleted.Name as [OldName], deleted.OwnerId [OldOwnerId]"
                            + ", inserted.Name as [NewName], inserted.OwnerId [NewOwnerId]"
                            + "from Product where ProductId=@productid";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.Add(new SqlParameter("@name",product.Name));
            command.Parameters.Add(new SqlParameter("@ownerid", product.OwnerId));
            command.Parameters.Add(new SqlParameter("@productid", product.ProductId));
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    updated = true;
                    string oldName = reader.GetString(0);
                    string oldOwnerId = reader.GetGuid(1).ToString();
                    string newName = reader.GetString(2);
                    string newOwnerId = reader.GetGuid(3).ToString();
                    
                    reader.Close();
                    
                    LogUpdate(product.ProductId, string.Format("Updated product {0}. Old Name: {1}, Old OwnerId: {2}, New Name: {3}, New OwnerId: {4}", product.ProductId, oldName, oldOwnerId, newName, newOwnerId));
                }
            }

            return updated;

        }

        public static bool DeleteProduct(Product product)
        {
            string query = "Delete from Product where ProductId=@productid";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@productid", product.ProductId);
            int rows = command.ExecuteNonQuery();

            if (rows > 0)
            {
                LogDelete(Guid.Empty, string.Format("Deleted {0} ({1})", product.Name, product.ProductId));
            }
            
            return rows > 0;
        }

        public static bool Register(User user)
        { 
            // TODO: Register log  ekle 
            if (!UserExists(user))
            {
                string query = "Insert into [User](Fullname , Email , Username , Password , RegistrationDate, IsAdmin) Values (@fullname, @email , @username , @password , @registerdate, 0)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@fullname", user.FullName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@registerdate", user.RegistrationDate);
                int rowCount = command.ExecuteNonQuery();
                return rowCount != 0; 
            }

            return false;
        }

        public static bool UserExists(User user)
        {
            string query = "SELECT 1 FROM [User] WHERE Username = @username or Email = @email";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@email", user.Email);
            var results = command.ExecuteScalar();
            return results != null;
        }

        public static void LogCreate(Guid recordId, string details)
        {
            LogOperation(recordId, details, "Create");
        }
        public static void LogUpdate(Guid recordId, string details)
        {
            LogOperation(recordId, details, "Update");
        }
        public static void LogDelete(Guid recordId, string details)
        {
            LogOperation(recordId, details, "Delete");
        }
        public static void LogOperation(Guid recordId, string details, string type)
        {
            AddLog(new OperationLog()
            {
                UserId = CurrentUser.UserId,
                RecordId = recordId,
                OperationType = type,
                OperationDetails = details,
                OperationDate = DateTime.Now
            });
        }
        public static void AddLog(OperationLog log)
        {
            string query = "INSERT INTO OperationLog (UserId, RecordId, OperationType, OperationDetails, OperationDate) "
                         + "VALUES (@UserId, @RecordId, @Type, @Details, @Date)";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@UserId", log.UserId);
            
            if (log.RecordId != Guid.Empty)
            {
                command.Parameters.AddWithValue("@RecordId", log.RecordId); 
            }
            else
            {
                command.Parameters.AddWithValue("@RecordId", DBNull.Value); 
            }
            
            command.Parameters.AddWithValue("@Type", log.OperationType);
            command.Parameters.AddWithValue("@Details", log.OperationDetails);
            command.Parameters.AddWithValue("@Date", log.OperationDate);
            command.ExecuteNonQuery();
        }

        public static DataTable GetLogTable()
        {
            string query = "select OperationType, FullName , OperationDetails,OperationDate from dbo.[Logs]";
            SqlCommand command = new SqlCommand(query, _connection);
            
            // Create adapter with command
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            
            // Create empty table
            DataTable table = new DataTable();
            
            // Fill the table
            adapter.Fill(table);

            return table;
        }

    }
}
