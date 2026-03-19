using InventoryOrderingSystem.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace InventoryOrderingSystem.Models.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly InventoryOrderingSystemContext _context;

        public OrderRepository(InventoryOrderingSystemContext context)
        {
            _context = context;
        }

       
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

     
        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            var orders = await _context.Orders.ToListAsync();
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

        
        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var orders = await _context.Orders.ToListAsync();
            var order = orders.FirstOrDefault(o => o.Id == orderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}