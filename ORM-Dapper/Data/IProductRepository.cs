using ORM_Dapper.Models;

namespace ORM_Dapper.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts(); 
    public void AddProduct(string name, double price, int stockLevel, bool onSale, int categoryId);
    public void UpdateProduct(int productId, string name, double price, int stockLevel, bool onSale, int categoryId);
    public void DeleteProduct(int productId);
    
}