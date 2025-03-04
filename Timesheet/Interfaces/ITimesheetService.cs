using Timesheet.Models.DTO;
using System.Threading.Tasks;

namespace Timesheet.Interfaces
{
    public interface ITimesheetService
    {
        // ✅ Submit a new timesheet
        Task<TimesheetResponseDto> SubmitTimesheet(SubmitTimesheetDto dto, int userId);

        // ✅ Approve timesheet (Only Manager & HR can do this)
        Task<string> ApproveTimesheet(int approverId, ApproveTimesheetDto dto);

        // ✅ Update timesheet (Allowed only if status is Pending)
        Task<TimesheetResponseDto> UpdateTimesheet(int timesheetId, UpdateTimesheetDto dto, int userId);

        // ✅ Delete timesheet (Allowed only if status is Pending)
        Task<bool> DeleteTimesheet(int timesheetId, int userId);
    }
}
