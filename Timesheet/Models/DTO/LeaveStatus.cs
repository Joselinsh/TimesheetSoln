using System.Collections.Generic;

namespace Timesheet.Models.DTO
{
    public class LeaveStatusDto
    {
        public string EmployeeName { get; set; }
        public List<LeaveDetailDto> Leaves { get; set; }
    }
}
