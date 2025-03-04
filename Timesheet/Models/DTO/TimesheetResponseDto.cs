namespace Timesheet.Models.DTO
{
    public class TimesheetResponseDto
    {
        public int TimesheetId { get; set; }
        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }
        public DateOnly Date { get; set; }
        public int HoursWorked { get; set; }
        public string Status { get; set; }
        
    }
}
