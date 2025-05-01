using System.Data;
using ORM_Dapper.Models;
using Dapper;

namespace ORM_Dapper.Data;


public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;
    
    public ProductRepository(IDbConnection connection)

    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public void AddProduct(string name, double price, int stockLevel, bool onSale, int categoryId)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryId, @onSale, @stockLevel);", 
            new {name, price, categoryId, onSale, stockLevel});
    }

    public void UpdateProduct(int productId, string name, double price, int stockLevel, bool onSale, int categoryId)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price, CategoryID = @categoryId, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @productId;", 
            new {name, price, categoryId, onSale, stockLevel, productId});
    }

    public void DeleteProduct(int productId)
    {
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productId;", new {productId });
        _connection.Execute("DELETE FROM sales WHERE ProductID = @productId;", new {productId });
        _connection.Execute("DELETE FROM products WHERE ProductID = @productId;", new { productId});
    }
}