using System.ComponentModel.DataAnnotations;

namespace Timesheet.Models.DTO
{
    public class UserRegistrationResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }




        public string Department { get; set; }

        public string Designation { get; set; }
        public DateOnly? JoiningDate { get; set; }

        public string Message { get; set; }
    }

}
