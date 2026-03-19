using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Repositories.Orders;
using InventoryOrderingSystem.Models.Services.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryOrderingSystem.Service.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        
        public async Task<bool> CreateOrderAsync(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
            return true;
        }

        
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
            return true;
        }

        
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

       
        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

       
        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}