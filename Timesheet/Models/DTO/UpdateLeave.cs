namespace Timesheet.Models.DTO
{
    public class UpdateLeaveDto
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; }
    }
}
