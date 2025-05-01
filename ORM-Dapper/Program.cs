using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System;
using ORM_Dapper.Data;

namespace ORM_Dapper;

    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            /*var depRepo = new DapperDepartmentRepository(conn);
            
            var departments = depRepo.GetAllDepartments();

            foreach (var dep in departments)
            {
                Console.WriteLine($"ID: {dep.DepartmentID} | Name: {dep.Name}");
            }*/

            var prodRepo = new ProductRepository(conn);
            
            //prodRepo.AddProduct("Monitor", 149.99, 10, false, 1);

            var products = prodRepo.GetAllProducts();
            
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductID} | NAME: {product.Name} | PRICE: {product.Price} | CATEGORY ID: {product.CategoryID} | SALE: {product.OnSale} | STOCK: {product.StockLevel}");
            }
                
        }
    }

