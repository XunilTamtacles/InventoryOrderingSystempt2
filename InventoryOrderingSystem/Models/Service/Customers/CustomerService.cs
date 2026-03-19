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
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int customerId)
        {
            var customer = _customerRepository.GetByIdAsync(customerId);

            if (customer == null)
            {
                throw new Exception($"Customer with ID {customerId} not found.");
            }

            return customer;
        }

        public async Task<Customer?> GetCustomerByNameAsync(string customerName)
        {
            var customer = await _customerRepository.GetByNameAsync(customerName);
            if (customer == null)
            {
                throw new Exception($"Customer with name {customerName} not found.");
            }
            return customer;
        }

       
        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
            return true;
        }

        
        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateCustomerAsync(customer);
        }

     
        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
            return true;
        }
    }
}