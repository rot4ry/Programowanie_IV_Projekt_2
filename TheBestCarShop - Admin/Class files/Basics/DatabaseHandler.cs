﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Dapper;

namespace TheBestCarShop___Admin.Class_files.Basics
{
    public class DatabaseHandler
    {
        private string connectionString = @"
                    Data Source=DESKTOP-GSQML5J\MYSERVER;
                    Initial Catalog=TheShop;
                    Integrated Security=True;
                    Connect Timeout=30;
                    Encrypt=False;
                    TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;
                    MultiSubnetFailover=False";


        //PRODUCT RELATED METHODS
        public int AddProduct(string brand, string model, int fyear, int lyear, double price, string name, string category, string manufacturer, string code, string isAvailable, int quantity)
        {
            int result = 0;
            string insert = 
                "INSERT INTO Products(" +
                "CarBrand, " +
                "CarModel, " +
                "CarFirstProdYear, " +
                "CarLastProdYear, " +
                "Price, " +
                "Name, " +
                "Category, " +
                "Manufacturer, " +
                "Code, " +
                "IsAvailable, " +
                "Quantity)  " +
                "VALUES(" +
                "@brand, " +
                "@model, " +
                "@fyear, " +
                "@lyear, " +
                "@price, " +
                "@name, " +
                "@category, " +
                "@manufacturer, " +
                "@code, " +
                "@isAvailable, " +
                "@quantity) ";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                result = connection.Execute(insert,
                                            new
                                            {
                                                brand = brand,
                                                model = model,
                                                fyear = fyear,
                                                lyear = lyear,
                                                price = price,
                                                name = name,
                                                category = category,
                                                manufacturer = manufacturer,
                                                code = code,
                                                isAvailable = isAvailable,
                                                quantity = quantity
                                            });
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return result;
        }

        public int UpdateProductField(string column, string newValue, int productID)
        {
            int affected = 0;
            string update = "UPDATE Products " +
                           $"SET {column} = @newValue " +
                            "WHERE ProductID = @productID ";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(update, new
                {
                    newValue = newValue,
                    productID = productID
                });
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return affected;
        }

        public List<Product> GetProductList()
        {
            List<Product> products;
            string select = "SELECT * FROM Products";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                products = connection.Query<Product>(select).ToList<Product>();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message); return (List<Product>)null;
            }
            return products;
        }

        public List<Product> GetAvailableProductsList()
        {
            List<Product> availableProductsList;

            string query = "SELECT * FROM Products WHERE IsAvailable=1";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                availableProductsList = connection.Query<Product>(query).ToList<Product>();
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);                return (List<Product>) null;
            }
            return availableProductsList;
        }
        public List<string> GetBrands()
        {
            List<string> brands = new List<string>();
            string select = "SELECT DISTINCT CarBrand " +
                            "FROM Products ";
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                brands = connection.Query<string>(select).ToList<string>();
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return (List<string>)brands;
        }

        public List<string> GetModelsByBrand(string brand)
        {
            List<string> brandsModels = new List<string>();
            string select = "SELECT DISTINCT CarModel " +
                            "FROM Products " +
                            "WHERE CarBrand = @brand ";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                brandsModels = connection.Query<string>(select,
                                                        new 
                                                        { 
                                                            brand = brand 
                                                        })
                                                        .ToList<string>();
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return brandsModels;
        }

        public List<string> GetManufacturers()
        {
            List<string> manufacturers = new List<string>();
            string select = "SELECT DISTINCT Manufacturer " +
                            "FROM Products ";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                manufacturers = connection.Query<string>(select).ToList<string>();
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return manufacturers;
        }
        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            string select = "SELECT DISTINCT Category " +
                            "FROM Products ";
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                categories = connection.Query<string>(select).ToList<string>();
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return categories;
        }

        public Product GetProduct(int id)
        {
            string query = "SELECT * FROM Products WHERE ProductID = @id";
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                Product product = connection.QuerySingle<Product>(query, new { id = id });
                connection.Close();

                return product;
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
                return (Product)null;
            }
        }
    
        //ORDER RELATED METHODS
        public int RemoveAllUnplacedOrders()
        {
            string select = "SELECT OrderID " +
                            "FROM Orders " +
                            "WHERE IsPlaced = 'false' ";

            string delete = "DELETE FROM Orders " +
                            "DELETE FROM OrderDetails " +
                            "WHERE OrderID = @unplacedOrderID ";
            
            int deleted = 0;
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                
                List<int> unplacedIDs = connection.Query<int>(select).ToList<int>();
                if (unplacedIDs != null)
                {
                    foreach (int item in unplacedIDs)
                    {
                        deleted += connection.Execute(delete, new { unplacedOrderID = item });
                    }
                }
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return deleted;
        }


        //ORDER DETAILS RELATED METHODS

        /*
         * none for now
         */

        //USER RELATED METHODS
        public int AddAdmin(Client admin, bool isAdmin = true)
        {
            string insert = "INSERT INTO Clients([FirstName], " +
                "[SecondName], [CompanyName], [Email], [PhoneNumber], [Country], " +
                "[City], [Street], [Postcode], [BuildingNumber], " +
                "[Username], [Password],[IsAdmin]) " +

                "VALUES(@firstName, @secondName, @companyName, @email, @phone, " +
                "@country, @city, @street, @postcode, @buildingNumber, @username, " +
                "@password, @isAdmin)";
            
            int affected = 0;

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(insert,
                            new
                            {
                                firstName = admin.FirstName,
                                secondName = admin.SecondName,
                                companyName = admin.CompanyName,
                                email = admin.Email,
                                phone = admin.PhoneNumber,
                                country = admin.Country,
                                city = admin.City,
                                street = admin.Street,
                                postcode = admin.Postcode,
                                buildingNumber = admin.BuildingNumber,
                                username = admin.Username,
                                password = admin.Password,
                                isAdmin = isAdmin
                            });

                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            
            return affected;
        }

        public bool CheckLoginData(string username, string password)
        {
            string select = "SELECT * FROM Clients " +
                            "WHERE Username = @username " +
                            "AND Password = @password " +
                            "AND IsAdmin = 'true' ";

            Client requestedClient = new Client();

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                requestedClient = connection.Query<Client>(select,
                                        new
                                        {
                                            username = username,
                                            password = password
                                        }).FirstOrDefault();

                if (requestedClient != null)
                    return true;
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return false;
        }

        public Client GetClientDetails(string username)
        {
            SqlConnection connection = new SqlConnection(this.connectionString);
            
            string query = @"SELECT 
                            [ClientID] 
                            ,[FirstName] 
                            ,[SecondName] 
                            ,[CompanyName] 
                            ,[Email] 
                            ,[PhoneNumber] 
                            ,[Country]
                            ,[City] 
                            ,[Street] 
                            ,[Postcode] 
                            ,[BuildingNumber]
                            ,[Username] 
                            ,[Password]
                            ,[IsAdmin] 
                            FROM Clients
                            WHERE Username = @username";
            try
            {
                Client client = connection.QuerySingle<Client>
                    (query, new { username = username });
                connection.Close();
                return client;
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
                return (Client)null;
            }
        }

        public List<Client> GetClientsList()
        {
            List<Client> clients = new List<Client>();
            string select = "SELECT * FROM Clients ";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                clients = connection.Query<Client>(select).ToList();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return clients;
        }

        public int UpdateClientField(string columnName, string value, string username, int userID)
        {
            int affected = 0;
            string update = "UPDATE Clients " +
                           $"SET {columnName} = @value " +
                            "WHERE Username = @username " +
                            "AND ClientID = @userID";   //ID alone would be enough and better
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(update, 
                    new { 
                        value = value, 
                        username = username,
                        userID = userID
                    });
                connection.Close();
            }
            catch (Exception DatabaseHandlerException) 
            { 
                Console.WriteLine(DatabaseHandlerException.Message); 
            }

            return affected;
        }
        
        public int DeleteUser(string username, int userID)
        {
            int affected = 0;

            string delete = "DELETE Clients WHERE Username = @username " +
                            "AND ClientID = @userID";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(delete, 
                    new { 
                        username = username,
                        userID = userID
                    });
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return affected;
        }

        //STATISTICS RELATED METHODS
        public ProductStatistic GetProductSalesDetails(int productID)
        {
            ProductStatistic productStatistic = new ProductStatistic();
            string select = "SELECT Min(ReceivedDate) as FirstBought, " +
                            "MAX(ReceivedDate) as LastBought, " +
                            "SUM(Quantity) as AmountSold " +
                            "FROM Orders INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID " +
                            "WHERE IsPlaced = 'true' AND ProductID = @productID " +
                            "GROUP BY ProductID";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                productStatistic = connection.QuerySingle<ProductStatistic>(select, 
                                                                        new { 
                                                                            productID = productID 
                                                                        });
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return productStatistic;
        }
    }
}


