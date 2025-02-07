using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Timesheet.Data;
using Timesheet.Interfaces;
using Timesheet.Models;
using Timesheet.Models.DTO;


namespace Timesheet.Services
{
    public class RoleService : IRoleService
    {
        private readonly TimesheetDbContext _context;

        public RoleService(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateUserRoleAsync(UpdateUserRoleDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);
            if (user == null) return false; // User not found

            if (user.Role != "Unassigned") return false; // Prevent reassigning roles

            user.Role = dto.Role;
            await _context.SaveChangesAsync();

            // ✅ Create entry in Employee or HR table
            if (dto.Role == "Employee")
            {
                var employee = new Employee
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Department = user.Department
                };
                _context.Employees.Add(employee);
            }
            else if (dto.Role == "HR")
            {
                var hr = new HR
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Department = user.Department
                };
                _context.HRs.Add(hr);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

