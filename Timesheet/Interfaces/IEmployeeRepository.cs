using Timesheet.Models;
using Timesheet.Models.DTO;

namespace Timesheet.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByUserId(int userId);
        Task<Employee> GetById(int employeeId);
        Task<Employee> GetByEmployeeId(int employeeId);

        Task<Employee> UpdateEmployeeProfile(int employeeId, UpdateEmployeeDto dto);

    }

}
