using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Repositories.Customers;

namespace InventoryOrderingSystem.Models.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        
        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task<Customer?> GetCustomerByNameAsync(string customerName)
        {
            return await _customerRepository.GetCustomerByNameAsync(customerName);
        }

       
        public async Task CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
        }

        
        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateCustomerAsync(customer);
        }

     
        public async Task DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}