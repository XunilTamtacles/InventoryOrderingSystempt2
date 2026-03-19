using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Repositories.OrderProductItems;

namespace InventoryOrderingSystem.Models.Services.OrderProductItems
{
    public class OrderProductItemService : IOrderProductItemService
    {
        private readonly IOrderProductItemRepository _repository;

        public OrderProductItemService(IOrderProductItemRepository repository)
        {
            _repository = repository;
        }

      
        public async Task<List<OrderProductItem>> GetAllOrderProductItemsAsync()
        {
            return await _repository.GetAllOrderProductItemsAsync();
        }

        public async Task<OrderProductItem?> GetOrderProductItemByIdAsync(int id)
        {
            return await _repository.GetOrderProductItemByIdAsync(id);
        }

        public async Task CreateOrderProductItemAsync(OrderProductItem item)
        {
            await _repository.AddOrderProductItemAsync(item);
        }

        public async Task UpdateOrderProductItemAsync(OrderProductItem item)
        {
            await _repository.UpdateOrderProductItemAsync(item);
        }

        public async Task DeleteOrderProductItemAsync(int id)
        {
            await _repository.DeleteOrderProductItemAsync(id);
        }
    }
}