using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Repositories.Orders
{
    public interface IOrderRepository
    {
       public Task<List<Order>> GetAllOrdersAsync();              
       public Task<Order?> GetOrderByIdAsync(int orderId);         
        public Task AddOrderAsync(Order order);                    
        public Task UpdateOrderAsync(Order order);                  
        public Task DeleteOrderAsync(int orderId);                 
    }
}