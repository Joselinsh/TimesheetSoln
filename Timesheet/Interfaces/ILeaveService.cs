using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheet.Models.DTO;

namespace Timesheet.Interfaces
{
    public interface ILeaveService
    {
        // ✅ Submit a new leave request
        Task<LeaveResponseDto> SubmitLeaveRequest(SubmitLeaveDto dto, int userId);

        // ✅ Approve leave request (Only Manager & HR can do this)
        Task<string> ApproveLeave(int approverId, ApproveLeaveDto dto);

        // ✅ Get all leave requests for an employee
        Task<List<LeaveResponseDto>> GetEmployeeLeaves(int employeeId);

        // ✅ Update leave request (Allowed only if status is Pending)
        Task<LeaveResponseDto> UpdateLeave(int leaveId, UpdateLeaveDto dto, int userId);

        // ✅ Delete leave request (Allowed only if status is Pending)
        Task<bool> DeleteLeave(int leaveId, int userId);
    }
}
