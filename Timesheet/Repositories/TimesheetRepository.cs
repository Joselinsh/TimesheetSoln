using Timesheet.Data;
using Timesheet.Interfaces;
using Timesheet.Models;
using Microsoft.EntityFrameworkCore;
using Timesheet.Models.DTO;
using Timesheet.Enum;


namespace Timesheet.Repositories
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly TimesheetDbContext _context;

        public TimesheetRepository(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<TimesheetDb> SubmitTimesheet(TimesheetDb timesheet)
        {
            _context.Timesheets.Add(timesheet);
            await _context.SaveChangesAsync();
            return timesheet;
        }

        public async Task<List<TimesheetDb>> GetEmployeeTimesheets(int employeeId)
        {
            return await _context.Timesheets.Where(t => t.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<TimesheetDb> GetTimesheetById(int timesheetId)
        {
            return await _context.Timesheets.FindAsync(timesheetId);
        }

        public async Task<TimesheetDb> UpdateTimesheet(TimesheetDb timesheet)
        {
            _context.Timesheets.Update(timesheet);
            await _context.SaveChangesAsync();
            return timesheet;
        }

        public async Task<List<TimesheetDb>> GetTimesheetsByEmployeeId(int employeeId)
        {
            return await _context.Timesheets
                .Where(t => t.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<TimesheetDb> UpdateTimesheet(int timesheetId, UpdateTimesheetDto dto)
        {
            var timesheet = await _context.Timesheets.FindAsync(timesheetId);
            if (timesheet == null) return null;

            timesheet.ProjectName = dto.ProjectName;
            timesheet.Date = dto.Date;
            timesheet.HoursWorked = dto.HoursWorked;


            await _context.SaveChangesAsync();
            return timesheet;
        }

        public async Task<bool> DeleteTimesheet(int timesheetId)
        {
            var timesheet = await _context.Timesheets.FindAsync(timesheetId);
            if (timesheet == null) return false;

            _context.Timesheets.Remove(timesheet);
            await _context.SaveChangesAsync();
            return true;
        }

       public async Task<List<TimesheetDb>> GetPendingTimesheets()
{
    return await _context.Timesheets
        .Where(ts => ts.Status == TimesheetStatus.Pending) // ✅ Use Enum value, not string
        .Include(l => l.Employee)
        .ToListAsync();
}

    }
}




