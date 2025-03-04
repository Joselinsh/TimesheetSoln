using Timesheet.Models;
using Timesheet.Models.DTO;

namespace Timesheet.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByUserId(int userId);
        Task<Employee> GetByIdAsync(int employeeId);
        Task<Employee> GetEmployeeByUserIdAsync(int userId);
        Task<Employee> GetByEmployeeId(int employeeId);

        Task<Employee> UpdateEmployeeProfile(int employeeId, UpdateEmployeeDto dto);

        Task<Employee> GetByUserIdWithTimesheetsAsync(int userId);

    }
}


