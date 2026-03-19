using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Repositories.Products;

namespace InventoryOrderingSystem.Models.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _repository.AddProductAsync(product);
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        public Task<Product?> GetProductByIdAsync(int productId)
        {
            return Task.FromResult<Product?>(null);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _repository.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            return true;
        }
    }
}