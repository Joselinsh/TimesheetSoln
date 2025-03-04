using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheet.Interfaces;
using Timesheet.Models;

namespace Timesheet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Where(u => u.Role == role);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
            await _userRepository.SaveChangesAsync();
        }
    }
}
