using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Services.Customers
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByNameAsync(string customerName);
        Task<Customer?> GetCustomerByIdAsync(int customerId);
        Task UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int customerId);
    }
}