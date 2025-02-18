using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheet.Data;
using Timesheet.Interfaces;
using Timesheet.Models;
using Timesheet.Repositories;

namespace Timesheet.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly TimesheetDbContext _context;

        public LeaveRepository(TimesheetDbContext context)
        {
            _context = context;
        }

        // Submit a new leave request
        public async Task<LeaveDb> SubmitLeaveRequest(LeaveDb leave)
        {
            _context.Leaves.Add(leave);
            await _context.SaveChangesAsync();
            return leave;
        }

        // Get a leave request by ID
        public async Task<LeaveDb> GetLeaveById(int leaveId)
        {
            return await _context.Leaves
                .Include(l => l.Employee) 
                .FirstOrDefaultAsync(l => l.Id == leaveId);
        }

        // Get all leave requests of an employee (with Employee details)
        public async Task<List<LeaveDb>> GetLeavesByEmployeeId(int employeeId)
        {
            return await _context.Leaves
                .Where(l => l.EmployeeId == employeeId)
                .Include(l => l.Employee) // Load Employee details
                .ToListAsync();
        }

        // Update an existing leave request (for approval/rejection)
        public async Task UpdateLeaveRequest(LeaveDb leave)
        {
            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();
        }
    }
}
