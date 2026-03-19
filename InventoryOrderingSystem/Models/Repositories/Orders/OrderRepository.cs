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

 
        public Task<Order?> GetOrderByIdAsync(int orderId)
        {
           
            return Task.FromResult<Order?>(null);
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

       
        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public Task DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}