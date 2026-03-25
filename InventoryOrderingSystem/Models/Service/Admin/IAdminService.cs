using InventoryOrderingSystem.Models.Database;
using System.Threading.Tasks;

namespace InventoryOrderingSystem.Repository.Admins
{
    public interface IAdminRepository
    {
        
        public Task AddAsync(Administrator admin);

       
        public Task<bool> AdminExists(string username);

       
       public Task<Administrator?> GetAdminByUsernameAsync(string username);
    }
}