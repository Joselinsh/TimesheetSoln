using System;

namespace Timesheet.Models.DTO
{
    public class LeaveDetailDto
    {
        public int LeaveId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Status { get; set; }
    }
}
