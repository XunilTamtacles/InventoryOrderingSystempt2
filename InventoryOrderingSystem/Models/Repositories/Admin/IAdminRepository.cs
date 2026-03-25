using InventoryOrderingSystem.Models.Database;

namespace InventoryOrderingSystem.Repository.Admins
{
    public interface IAdminRepository
    {
        Task<Administrator?> GetByUsernameAsync(string username);

        Task AddAsync(Administrator admin);

        Task<bool> ExistsAsync(string username);
        Task GetAdminUserAsync(object username);
    }
}