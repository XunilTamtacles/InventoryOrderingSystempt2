using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Repositories.Orders;

namespace InventoryOrderingSystem.Models.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            await _repository.AddOrderAsync(order);
            return true;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _repository.GetAllOrdersAsync();
        }

        public Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return Task.FromResult<Order?>(null);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _repository.UpdateOrderAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return true;
        }
    }
}