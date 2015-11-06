﻿using DatabaseHelper.Models;
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
        private static User CurrentUser { get; set; }

        public static bool IsConnected 
        { 
            get 
            { 
                return _connection.State.Equals(ConnectionState.Open); 
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
            command.Parameters.Add("@ownerid", CurrentUser.UserId);

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
            command.Parameters.Add("@ownerid", userId);


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

            string query = "SELECT UserId, FullName, Username, Email, RegistrationDate FROM dbo.[User]";

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
                        RegistrationDate = reader.GetDateTime(4)
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
                LogUpdate(CurrentUser.UserId, product.ProductId, "Stock updated from " + ((stockInfo != null) ? stockInfo.Count : 0) +  " to " + count);
            }

            return rows > 0;

        }

        public static bool CreateProduct(Product product)
        {
            string query="";
            if (!ProductExists(product))
            {
                query = "insert into product (Name,OwnerId) values (@name , @ownerid)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.Add("@name", product.Name);
                command.Parameters.Add("@ownerid", product.OwnerId);
                int rows = command.ExecuteNonQuery();
                
                return rows > 0;
            }
            else
                return false;
        }

        private static bool ProductExists(Product product)
        {
            string query = "Select 1 from Product where name=@name";
            SqlCommand command = new SqlCommand(query,_connection);
            command.Parameters.Add("@name", product.Name);
            var result = command.ExecuteScalar();
            return result != null;
        }

        public static bool UpdateProduct(Product product)
        {
            string query = "Update Product Set Name = @name, OwnerId=@ownerid from Product Where ProductId=@productid";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.Add(new SqlParameter("@name",product.Name));
            command.Parameters.Add(new SqlParameter("@ownerid", product.OwnerId));
            command.Parameters.Add(new SqlParameter("@productid", product.ProductId));
            int rows = command.ExecuteNonQuery();
            return rows > 0;

        }

        public static bool DeleteProduct(Product product)
        {
            string query = "Delete from Product where ProductId=@productid";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.Add("@productid", product.ProductId);
            int rows = command.ExecuteNonQuery();
            return rows > 0;
        }

        public static bool Register(User user)
        {
            if (!UserExists(user))
            {
                string query = "Insert into [User](Fullname , Email , Username , Password , RegistrationDate) Values (@fullname, @email , @username , @password , @registerdate)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.Add("@fullname", user.FullName);
                command.Parameters.Add("@email", user.Email);
                command.Parameters.Add("@username", user.Username);
                command.Parameters.Add("@password", user.Password);
                command.Parameters.Add("@registerdate", user.RegistrationDate);
                int rowCount = command.ExecuteNonQuery();
                return rowCount != 0; 
            }

            return false;
        }

        private static bool UserExists(User user)
        {
            string query = "SELECT 1 FROM [User] WHERE Username = @username or Email = @email";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.Add("@username", user.Username);
            command.Parameters.Add("@email", user.Email);
            var results = command.ExecuteScalar();
            return results != null;
        }

        private static void LogCreate(Guid currentUserId, Guid recordId, string details)
        {
            AddLog(new OperationLog()
            {
                UserId = currentUserId,
                RecordId = recordId,
                OperationType = "Create",
                OperationDetails = details,
                OperationDate = DateTime.Now
            });
        }
        private static void LogUpdate(Guid currentUserId, Guid recordId, string details)
        {
            AddLog(new OperationLog()
            {
                UserId = currentUserId,
                RecordId = recordId,
                OperationType = "Update",
                OperationDetails = details,
                OperationDate = DateTime.Now
            });
        }
        private static void LogDelete(Guid currentUserId, Guid recordId, string details)
        {
            AddLog(new OperationLog()
            {
                UserId = currentUserId,
                RecordId = recordId,
                OperationType = "Delete",
                OperationDetails = details,
                OperationDate = DateTime.Now
            });
        }
        private static void AddLog(OperationLog log)
        {
            string query = "INSERT INTO OperationLog (UserId, RecordId, OperationType, OperationDetails, OperationDate) "
                         + "VALUES (@UserId, @RecordId, @Type, @Details, @Date)";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.Add("@UserId", log.UserId);
            command.Parameters.Add("@RecordId", log.RecordId);
            command.Parameters.Add("@Type", log.OperationType);
            command.Parameters.Add("@Details", log.OperationDetails);
            command.Parameters.Add("@Date", log.OperationDate);
            command.ExecuteNonQuery();
        }

    }
}
