using System;
using Timesheet.Data;
using Timesheet.Models;
using Microsoft.EntityFrameworkCore;
using Timesheet.Interfaces;

namespace Timesheet.Repositories
{
    public class HRRepository : IHRRepository
    {
        private readonly TimesheetDbContext _context;

        public HRRepository(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<HR> GetByUserId(int userId)
        {
            return await _context.HRs
                .Include(hr => hr.User) 
                .FirstOrDefaultAsync(hr => hr.UserId == userId);
        }

    }

}
