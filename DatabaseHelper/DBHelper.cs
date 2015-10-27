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
            
            return result != null;
        }

        public static List<Product> GetProducts() 
        {
            List<Product> products = new List<Product>();

            string query = "SELECT p.ProductId, p.Name, p.OwnerId, u.FullName "
                         + "FROM dbo.[Product] p "
                         + "INNER JOIN dbo.[User] u ON u.UserId = p.OwnerId";

            SqlCommand command = new SqlCommand(query, _connection);


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
    }
}
