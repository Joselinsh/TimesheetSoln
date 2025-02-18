using Timesheet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheet.Interfaces
{
    public interface ILeaveRepository
    {
        // Submit a new leave request
        Task<LeaveDb> SubmitLeaveRequest(LeaveDb leave);

        // Get a leave request by its ID
        Task<LeaveDb> GetLeaveById(int leaveId);

        // Get all leave requests for a specific employee
        Task<List<LeaveDb>> GetLeavesByEmployeeId(int employeeId);

        // Update leave request status (Approve/Reject)
        Task UpdateLeaveRequest(LeaveDb leave);
    }
}
