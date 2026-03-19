using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Services.Orders
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(Order order);

        Task<List<Order>> GetAllOrdersAsync();

        Task<Order?> GetOrderByIdAsync(int orderId);

        Task UpdateOrderAsync(Order order);

        Task<bool> DeleteOrderAsync(int orderId);
    }
}