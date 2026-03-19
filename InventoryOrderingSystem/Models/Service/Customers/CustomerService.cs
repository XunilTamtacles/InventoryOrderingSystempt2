using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Service.Customers
{
    public interface ICustomerService
    {
        public Task<bool> CreateCustomerAsync(Customer customer);

      public Task<List<Customer>> GetAllCustomerAsync();

        public Task<Customer?> GetCustomerByNameAsync(string customerName);

        public Task<Customer?> GetCustomerByIdAsync(int customerId);

        public Task UpdateCustomerAsync(Customer customer);

        public Task<bool> DeleteCustomerAsync(int customerId);

    }
}
