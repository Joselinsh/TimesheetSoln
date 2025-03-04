using Timesheet.Data;
using Timesheet.Interfaces;
using Timesheet.Models;
using Microsoft.EntityFrameworkCore;
using Timesheet.Models.DTO;


namespace Timesheet.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TimesheetDbContext _context;

        public EmployeeRepository(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetByUserId(int userId)
        {
            return await _context.Employees
                                  .Include(e => e.User)
                                 .FirstOrDefaultAsync(e => e.UserId == userId);
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _context.Employees
                                 .Include(e => e.Timesheets)
                                 .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> GetEmployeeByUserIdAsync(int userId)
        {
            return await _context.Employees
                                 .Include(e => e.User) // Load related User details
                                    .Include(e => e.Timesheets)
                                 .FirstOrDefaultAsync(e => e.UserId == userId);
        }


        public async Task<Employee> GetByEmployeeId(int employeeId)
        {
            return await _context.Employees
                .Include(e => e.User) // Load User details
                .Include(e => e.Timesheets) // Load Timesheets
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> UpdateEmployeeProfile(int employeeId, UpdateEmployeeDto dto)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null) return null;

            employee.FullName = dto.FullName;
            employee.Email = dto.Email;
            employee.Department = dto.Department;
            employee.Designation = dto.Designation;

            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetByUserIdWithTimesheetsAsync(int userId)
        {
            return await _context.Employees
                .Include(e => e.User)  // ✅ Ensure User details are included
                .Include(e => e.Timesheets) // ✅ Ensure Timesheets are included
                
                .FirstOrDefaultAsync(e => e.UserId == userId);
        }




    }

}
