using InventoryOrderingSystem.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace InventoryOrderingSystem.Repository.Admins
{
    public class AdminRepository : IAdminRepository
    {
        private readonly InventoryOrderingSystemContext _context;

        public AdminRepository(InventoryOrderingSystemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Administrator admin)
        {
            _context.Administrators.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<Administrator?> GetByUsernameAsync(string username)
        {
            return await _context.Administrators
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await _context.Administrators
                .AnyAsync(x => x.Username == username);
        }
    }
}