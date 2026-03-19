using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Repositories.Products
{
    public interface IProductRepository
    {
      public Task<List<Product>> GetAllProductsAsync();      
      public Task<Product?> GetProductByIdAsync(int productId); 
      public  Task AddProductAsync(Product product);          
      public Task UpdateProductAsync(Product product);      
      public Task DeleteProductAsync(int productId);

    }
}
