using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Services.Products
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(Product product);

        Task<List<Product>> GetAllProductsAsync();

        Task<Product?> GetProductByIdAsync(int productId);

        Task UpdateProductAsync(Product product);

        Task<bool> DeleteProductAsync(int productId);
    }
}