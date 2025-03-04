using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Timesheet.Enum;

namespace Timesheet.Models
{
    public class TimesheetDb
    {
        [Key]
        public int TimesheetId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string ProjectName { get; set; }
        public DateOnly Date { get; set; }
        public int HoursWorked { get; set; }
        public string Description { get; set; }

      

        public TimesheetStatus Status { get; set; } = TimesheetStatus.Pending; // Default is Pending
    }
}
