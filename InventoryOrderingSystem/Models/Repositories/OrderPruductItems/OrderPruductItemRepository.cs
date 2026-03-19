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

      
        public async Task<OrderProductItem?> GetOrderProductItemByIdAsync(int orderProductItemId)
        {
            var items = await _context.OrderProductItems.ToListAsync();
            return items.FirstOrDefault(i => i.Id == orderProductItemId);
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

        
        public async Task DeleteOrderProductItemAsync(int orderProductItemId)
        {
            var items = await _context.OrderProductItems.ToListAsync();
            var item = items.FirstOrDefault(i => i.Id == orderProductItemId);

            if (item != null)
            {
                _context.OrderProductItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}