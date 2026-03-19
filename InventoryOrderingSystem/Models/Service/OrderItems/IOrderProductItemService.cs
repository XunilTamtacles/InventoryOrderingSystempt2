using InventoryOrderingSystem.Models.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryOrderingSystem.Models.Services.OrderProductItems
{
    public interface IOrderProductItemService
    {
        Task<List<OrderProductItem>> GetAllOrderProductItemsAsync();

        Task<OrderProductItem?> GetOrderProductItemByIdAsync(int id);

        Task CreateOrderProductItemAsync(OrderProductItem item);

        Task UpdateOrderProductItemAsync(OrderProductItem item);

        Task DeleteOrderProductItemAsync(int id);

        Task<bool> CreateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);



    }
}