using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Models.Repositories.Customers
{
    public interface ICustomerRepository
    {
    
        public Task<List<Customer>> GetAllCustomersAsync();
    
        public Task<Customer?> GetCustomerByIdAsync(int customerId);
    
        public Task<Customer?> GetCustomerByNameAsync(string customerName);
     
        public Task UpdateCustomerAsync(Customer customer);
      
        public Task DeleteCustomerAsync(int customerId);


    }
}