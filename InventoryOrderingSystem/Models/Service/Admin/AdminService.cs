using InventoryOrderingSystem.Helpers;
using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Repository.Admins;
using System.Threading.Tasks;

namespace InventoryOrderingSystem.Service.Admins
{
    public class AdminsService : IAdminsService
    {
        private readonly IAdminRepository _adminRepo;

        public AdminsService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        // Register a new admin
        public async Task RegisterAdminAsync(Administrator admin)
        {
            // Hash the password before saving
            admin.Password = SecurityHelper.HashPassword(admin.Password);

            await _adminRepo.AddAsync(admin);
        }

        // Check if an admin exists
        public Task<bool> AdminExists(string username)
        {
            return _adminRepo.AdminExists(username);
        }

       
        public async Task<LoginResponseModel> LoginAdminAsync(string username, string password)
        {
            var storedAdmin = await _adminRepo.GetAdminByUsernameAsync(username);
            var result = new LoginResponseModel { LoginSuccessful = false, IsAdmin = true };

            if (storedAdmin != null && SecurityHelper.VerifyPassword(password, storedAdmin.Password))
            {
                result.LoginSuccessful = true;
                result.UserId = storedAdmin.Id;
            }

            return result;
        }

        // Get admin by username
        public Task<Administrator?> GetAdminByUsernameAsync(string username)
        {
            return _adminRepo.GetAdminByUsernameAsync(username);
        }
    }
}