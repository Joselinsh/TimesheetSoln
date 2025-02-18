using System;

namespace Timesheet.Models.DTO
{
    public class SubmitLeaveDto
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; }
    }
}
