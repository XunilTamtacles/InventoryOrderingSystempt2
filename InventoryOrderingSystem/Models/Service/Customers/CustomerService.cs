using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Models.Repositories.Customers;
using InventoryOrderingSystem.Models.Services.Customers;
using System.Threading.Tasks;

namespace InventoryOrderingSystem.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CustomerExists(string username)
        {
            var allCustomers = await _repository.GetAllCustomersAsync();
            return allCustomers.Exists(c => c.Username == username);
        }

        public async Task<LoginResponseModel> LoginCustomer(LoginModel model)
        {
            var allCustomers = await _repository.GetAllCustomersAsync();
            var customer = allCustomers.Find(c => c.Username == model.Username && c.Password == model.Password);

            if (customer != null)
            {
                return new LoginResponseModel
                {
                    LoginSuccessful = true,
                    UserId = customer.Id,
                    IsAdmin = false
                };
            }

            return new LoginResponseModel { LoginSuccessful = false };
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _repository.AddCustomerAsync(customer);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _repository.GetAllCustomersAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            var customers = await _repository.GetAllCustomersAsync();
            return customers.Find(x => x.Id == id);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _repository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteCustomerAsync(id);
        }
    }
}