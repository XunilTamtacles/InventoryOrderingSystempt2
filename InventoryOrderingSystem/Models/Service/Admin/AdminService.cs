using InventoryOrderingSystem.Helpers;
using InventoryOrderingSystem.Models.Database;
using InventoryOrderingSystem.Repository.Admins;
using System.Threading.Tasks;

namespace InventoryOrderingSystem.Service.Admins
{
    public class AdminsService : IAdminRepository
    {
        private readonly IAdminRepository _adminRepo;

        public AdminsService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

     
        public async Task RegisterAdminAsync(Administrator admin)
        {
         
            admin.Password = SecurityHelper.HashPassword(admin.Password);
            await _adminRepo.AddAsync(admin);
        }

        
        public Task<bool> AdminExists(string username)
        {
            return _adminRepo.AdminExists(username);
        }

        
        public async Task<Administrator?> LoginAdminAsync(string username, string password)
        {
            var storedAdmin = await _adminRepo.GetAdminByUsernameAsync(username);

            if (storedAdmin != null && SecurityHelper.VerifyPassword(password, storedAdmin.Password))
            {
                return storedAdmin; 
            }

            return null; 
        }

        
        public Task<Administrator?> GetAdminByUsernameAsync(string username)
        {
            return _adminRepo.GetAdminByUsernameAsync(username);
        }
    }
}