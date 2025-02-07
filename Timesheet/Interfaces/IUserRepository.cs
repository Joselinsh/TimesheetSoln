using Timesheet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheet.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
