using Timesheet.Models;

namespace Timesheet.Interfaces
{
    public interface ITimesheetRepository
    {
        Task<TimesheetDb> SubmitTimesheet(TimesheetDb timesheet);
        Task<List<TimesheetDb>> GetEmployeeTimesheets(int employeeId);
        Task<TimesheetDb> GetTimesheetById(int timesheetId);
        Task<TimesheetDb> UpdateTimesheet(TimesheetDb timesheet);

        Task<bool> DeleteTimesheet(int timesheetId);

        Task<List<TimesheetDb>> GetTimesheetsByEmployeeId(int employeeId);

    }
}
