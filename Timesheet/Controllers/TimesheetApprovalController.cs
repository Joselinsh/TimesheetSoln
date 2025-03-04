using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Interfaces;
using Timesheet.Models.DTO;
using Timesheet.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Timesheet.Controllers
{
    [Route("api/timesheets/approve")]
    [ApiController]
    public class TimesheetApprovalController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;
        private readonly IEmployeeRepository _employeeRepository; // To check Managers
        private readonly IHRRepository _HRRepository; // To check HR users

        public TimesheetApprovalController(ITimesheetService timesheetService, IEmployeeRepository employeeRepository, IHRRepository HRRepository)
        {
            _timesheetService = timesheetService;
            _employeeRepository = employeeRepository;
            _HRRepository = HRRepository;
        }

        [HttpPost]
        [Authorize] // No need to specify roles, as we check manually
        public async Task<IActionResult> ApproveTimesheet([FromBody] ApproveTimesheetDto dto)
        {
            var approverId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); // Get user ID from JWT

            // Check if the approver is a Manager (from Employee table)
            var employeeApprover = await _employeeRepository.GetByUserId(approverId);

            // Check if the approver is HR (from HR table)
            var hrApprover = await _HRRepository.GetByUserId(approverId);

            if (employeeApprover == null && hrApprover == null)
            {
                return Unauthorized("Approver not found.");
            }

            // Only Managers or HR can approve timesheets
            if ((employeeApprover?.Designation.Contains("Manager") == true) || (hrApprover != null))
            {
                var result = await _timesheetService.ApproveTimesheet(approverId, dto);
                return Ok(new { message = result });
            }

            return Unauthorized("You do not have the necessary permissions to approve timesheets.");
        }

    }
}

