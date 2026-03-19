using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Repositories.OrderPruductItems;
using Microsoft.EntityFrameworkCore;

namespace InventoryOrderingSystem.Models.Repositories.OrderProductItems
{
    public class OrderProductItemRepository : IOrderProductItemRepository
    {
        private readonly InventoryOrderingSystemContext _context;

        public OrderProductItemRepository(InventoryOrderingSystemContext context)
        {
            _context = context;
        }

        public async Task<List<OrderProductItem>> GetAllOrderProductItemsAsync()
        {
            return await _context.OrderProductItems.ToListAsync();
        }

      
        public Task<OrderProductItem?> GetOrderProductItemByIdAsync(int orderProductItemId)
        {
           
            return Task.FromResult<OrderProductItem?>(null);
        }

       
        public async Task AddOrderProductItemAsync(OrderProductItem orderProductItem)
        {
            await _context.OrderProductItems.AddAsync(orderProductItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderProductItemAsync(OrderProductItem orderProductItem)
        {
            _context.OrderProductItems.Update(orderProductItem);
            await _context.SaveChangesAsync();
        }

      
        public async Task DeleteOrderProductItemAsync(OrderProductItem orderProductItem)
        {
            _context.OrderProductItems.Remove(orderProductItem);
            await _context.SaveChangesAsync();
        }

        public Task DeleteOrderProductItemAsync(int orderProductItemId)
        {
            throw new NotImplementedException();
        }
    }
}