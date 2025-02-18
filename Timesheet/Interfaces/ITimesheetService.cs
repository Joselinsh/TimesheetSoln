using Timesheet.Models.DTO;

namespace Timesheet.Interfaces
{
    public interface ITimesheetService
    {
        Task<TimesheetResponseDto> SubmitTimesheet(SubmitTimesheetDto dto, int userId);
        Task<string> ApproveTimesheet(int approverId, ApproveTimesheetDto dto);
    }

}
