using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Timesheet.Interfaces;
using Timesheet.Models.DTO;
using Timesheet.Enum;

namespace Timesheet.Controllers
{
    [Route("api/employee")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly ITimesheetService _timesheetService;
        private readonly ILeaveService _leaveService;

        public EmployeeController(IEmployeeRepository employeeRepository,
                                  ITimesheetRepository timesheetRepository,
                                  ITimesheetService timesheetService,
                                  ILeaveService leaveService)
        {
            _employeeRepository = employeeRepository;
            _timesheetRepository = timesheetRepository;
            _timesheetService = timesheetService;
            _leaveService = leaveService;
        }

        // ✅ Get logged-in employee's profile
        [HttpGet("Profile")]
        public async Task<IActionResult> GetEmployeeProfile()
        {
            int userId = GetLoggedInUserId();
           
            var employee = await _employeeRepository.GetByUserIdWithTimesheetsAsync(userId);


            if (employee == null)
                return NotFound("Employee profile not found.");

            return Ok(new
            {
                employee.EmployeeId,
                employee.FullName,
                employee.Email,
                employee.Department,
                employee.Designation,
                Timesheets = employee.Timesheets.Select(t => new
                {
                    t.TimesheetId,
                    t.ProjectName,
                    t.Date,
                    t.HoursWorked,
                    t.Description,
                    Status = t.Status.ToString()
                }).ToList()
            });
        }

        // ✅ Get logged-in employee's timesheets
        [HttpGet("Timesheets")]
        public async Task<IActionResult> GetEmployeeTimesheets()
        {
            int userId = GetLoggedInUserId();
            var employee = await _employeeRepository.GetByUserId(userId);

            if (employee == null)
                return NotFound("Employee not found.");

            var timesheets = await _timesheetRepository.GetTimesheetsByEmployeeId(employee.EmployeeId);

            if (!timesheets.Any())
                return NotFound("No timesheets found.");

            return Ok(timesheets.Select(t => new
            {
                t.TimesheetId,
                t.ProjectName,
                t.Date,
                t.HoursWorked,
                t.Description,
                Status = t.Status.ToString()
            }));
        }


        [HttpGet("Leaves")]
        public async Task<IActionResult> GetEmployeeLeaves()
        {
            int userId = GetLoggedInUserId();
            var employee = await _employeeRepository.GetByUserId(userId);

            if (employee == null)
                return NotFound("Employee not found.");

            var leaves = await _leaveService.GetEmployeeLeaves(employee.EmployeeId);

            if (!leaves.Any())
                return NotFound("No leave requests found.");

            return Ok(leaves.Select(l => new
            {

                l.Id,
                l.StartDate,
                l.EndDate,
                Status = l.Status.ToString()
            }));
        }

        // ✅ Submit a new timesheet (Allowed)
        [HttpPost("Timesheets/Submit")]
        public async Task<IActionResult> SubmitTimesheet([FromBody] SubmitTimesheetDto dto)
        {
            int userId = GetLoggedInUserId();
            var result = await _timesheetService.SubmitTimesheet(dto, userId);
            return Ok(new { message = "Timesheet submitted successfully!", data = result });
        }


        // ✅ Update a timesheet (Allowed ONLY if Pending)
        [HttpPut("Timesheets/Update/{timesheetId}")]
        public async Task<IActionResult> UpdateTimesheet(int timesheetId, [FromBody] UpdateTimesheetDto dto)
        {
            int userId = GetLoggedInUserId();
            var result = await _timesheetService.UpdateTimesheet(timesheetId, dto, userId);
            return result != null
                ? Ok(new { message = "Timesheet updated successfully!", data = result })
                : BadRequest("Timesheet cannot be updated because it is already approved or rejected.");
        }



        // ✅ Delete a timesheet (Allowed ONLY if Pending)
        [HttpDelete("Timesheets/Delete/{timesheetId}")]
        public async Task<IActionResult> DeleteTimesheet(int timesheetId)
        {
            int userId = GetLoggedInUserId();
            bool isDeleted = await _timesheetService.DeleteTimesheet(timesheetId, userId);
            return isDeleted
                ? Ok("Timesheet deleted successfully.")
                : BadRequest("Timesheet cannot be deleted because it is already approved or rejected.");
        }


        // ✅ Submit a new leave request (Allowed)
        [HttpPost("Leaves/Submit")]
        public async Task<IActionResult> SubmitLeave([FromBody] SubmitLeaveDto dto)
        {
            int userId = GetLoggedInUserId();
            var result = await _leaveService.SubmitLeaveRequest(dto, userId);
            return Ok(new { message = "Leave request submitted successfully!", data = result });
        }


        // ✅ Update a leave request (Allowed ONLY if Pending)
        [HttpPut("Leaves/Update/{leaveId}")]
        public async Task<IActionResult> UpdateLeave(int leaveId, [FromBody] UpdateLeaveDto dto)
        {
            int userId = GetLoggedInUserId();
            var result = await _leaveService.UpdateLeave(leaveId, dto, userId);
            return result != null
                ? Ok(new { message = "Leave request updated successfully!", data = result })
                : BadRequest("Leave request cannot be updated because it is already approved or rejected.");
        }


        // ✅ Delete a leave request (Allowed ONLY if Pending)
        [HttpDelete("Leaves/Delete/{leaveId}")]
        public async Task<IActionResult> DeleteLeave(int leaveId)
        {
            int userId = GetLoggedInUserId();
            bool isDeleted = await _leaveService.DeleteLeave(leaveId, userId);
            return isDeleted
                ? Ok("Leave request deleted successfully.")
                : BadRequest("Leave request cannot be deleted because it is already approved or rejected.");
        }


        // ✅ Helper Method: Get logged-in user's ID from JWT token
        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : throw new UnauthorizedAccessException("User ID not found in token.");
        }
    }
}




