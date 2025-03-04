using Timesheet.Models;
using System.Threading.Tasks;

namespace Timesheet.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admins> GetAdminByUserIdAsync(int userId);
        Task AddAdminAsync(Admins admin);
        Task SaveChangesAsync();
    }
}
