using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheet.Models.DTO;

namespace Timesheet.Interfaces
{
    public interface ILeaveService
    {
        Task<LeaveResponseDto> SubmitLeaveRequest(SubmitLeaveDto dto, int userId);
        Task<string> ApproveLeave(int approverId, ApproveLeaveDto dto);
        Task<List<LeaveResponseDto>> GetEmployeeLeaves(int employeeId);

       // Task<LeaveResponseDto> GetLeaveById(int leaveId);
       // Task<LeaveResponseDto> UpdateLeave(int leaveId, UpdateLeaveDto dto);
        //Task<bool> DeleteLeave(int leaveId);
    }
}
