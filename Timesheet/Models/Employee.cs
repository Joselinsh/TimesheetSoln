using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } // Navigation property

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public ICollection<TimesheetDb> Timesheets { get; set; } = new List<TimesheetDb>();

        public ICollection<LeaveDb> LeaveRequests { get; set; } = new List<LeaveDb>(); // Add this line
    }
}

