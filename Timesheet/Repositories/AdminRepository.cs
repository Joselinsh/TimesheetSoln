using Microsoft.EntityFrameworkCore;
using Timesheet.Data;
using Timesheet.Interfaces;
using Timesheet.Models;
using System.Threading.Tasks;

namespace Timesheet.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TimesheetDbContext _context;

        public AdminRepository(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Admins> GetAdminByUserIdAsync(int userId)
        {
            return await _context.Admins
                .FirstOrDefaultAsync(a => a.UserId == userId);
                
        }

        public async Task AddAdminAsync(Admins admin)
        {
            await _context.Admins.AddAsync(admin);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
