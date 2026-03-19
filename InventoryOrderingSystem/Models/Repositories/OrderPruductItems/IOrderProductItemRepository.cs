using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Repositories.OrderPruductItems
{
    public interface IOrderProductItemRepository

    {
        public Task<List<OrderProductItem>> GetAllOrderProductItemsAsync();

        public Task<OrderProductItem?> GetOrderProductItemByIdAsync(int orderProductItemId);    

        public Task AddOrderProductItemAsync(OrderProductItem orderProductItem);

        public Task UpdateOrderProductItemAsync(OrderProductItem orderProductItem);

        public Task DeleteOrderProductItemAsync(int orderProductItemId);
    }
}
