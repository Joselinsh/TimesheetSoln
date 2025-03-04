namespace Timesheet.Models.DTO
{
    public class UpdateTimesheetDto
    {
        public string ProjectName { get; set; }
        public DateOnly Date { get; set; }
        public int HoursWorked { get; set; }
        public string Description { get; set; }

    }
}
