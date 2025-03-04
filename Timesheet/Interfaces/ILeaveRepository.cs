using Timesheet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheet.Interfaces
{
    public interface ILeaveRepository
    {
        // ✅ Submit a new leave request
        Task<LeaveDb> SubmitLeaveRequest(LeaveDb leave);

        // ✅ Get a leave request by its ID
        Task<LeaveDb> GetLeaveById(int leaveId);

        // ✅ Get all leave requests for a specific employee
        Task<List<LeaveDb>> GetLeavesByEmployeeId(int employeeId);

        
           Task<List<LeaveDb>> GetPendingLeaveRequests();
        


        // ✅ Update leave request (Only if status is Pending)
        Task<LeaveDb> UpdateLeaveRequest(LeaveDb leave);

        // ✅ Delete leave request (Only if status is Pending)
        Task<bool> DeleteLeaveRequest(int leaveId);
    }
}
