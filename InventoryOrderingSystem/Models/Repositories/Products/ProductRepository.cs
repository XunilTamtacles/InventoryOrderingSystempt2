using InventoryOrderingSystem.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace InventoryOrderingSystem.Models.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryOrderingSystemContext _context;

        public ProductRepository(InventoryOrderingSystemContext context)
        {
            _context = context;
        }

     
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        
        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

     
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}