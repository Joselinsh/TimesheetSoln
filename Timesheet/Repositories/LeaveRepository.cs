using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheet.Data;
using Timesheet.Enum;
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



        public async Task<LeaveDb> UpdateLeaveRequest(LeaveDb leave)
        {
            var existingLeave = await _context.Leaves.FindAsync(leave.Id);
            if (existingLeave == null || existingLeave.Status != LeaveStatus.Pending)
                return null; // Cannot update if not found or status is not Pending

            existingLeave.StartDate = leave.StartDate;
            existingLeave.EndDate = leave.EndDate;
            existingLeave.Reason = leave.Reason;

            _context.Leaves.Update(existingLeave);
            await _context.SaveChangesAsync();
            return existingLeave;
        }

        // ✅ Delete a leave request (Only if status is Pending)
        public async Task<bool> DeleteLeaveRequest(int leaveId)
        {
            var leave = await _context.Leaves.FindAsync(leaveId);
            if (leave == null || leave.Status != LeaveStatus.Pending)
                return false; // Cannot delete if not found or already approved/rejected

            _context.Leaves.Remove(leave);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<LeaveDb>> GetPendingLeaveRequests()
        {
            return await _context.Leaves
                .Where(lr => lr.Status == LeaveStatus.Pending) // ✅ Use Enum value, not string
                .Include(l => l.Employee)
                .ToListAsync();
        }

    }
}


