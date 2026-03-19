using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Repositories.OrderProductItems
{
    public interface IOrderProductItemRepository
    {
        Task<List<OrderProductItem>> GetAllOrderProductItemsAsync();

        Task<OrderProductItem?> GetOrderProductItemByIdAsync(int orderProductItemId);

        Task AddOrderProductItemAsync(OrderProductItem orderProductItem);

        Task UpdateOrderProductItemAsync(OrderProductItem orderProductItem);

        Task DeleteOrderProductItemAsync(int orderProductItemId);
    }
}