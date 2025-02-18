using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Interfaces;
using Timesheet.Models.DTO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Timesheet.Controllers
{
    [Route("api/leaves/approve")]
    [ApiController]
    public class LeaveApprovalController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        private readonly IEmployeeRepository _employeeRepository; // To check Managers
        private readonly IHRRepository _HRRepository; // To check HR users

        public LeaveApprovalController(ILeaveService leaveService, IEmployeeRepository employeeRepository, IHRRepository HRRepository)
        {
            _leaveService = leaveService;
            _employeeRepository = employeeRepository;
            _HRRepository = HRRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ApproveLeave([FromBody] ApproveLeaveDto dto)
        {
            var approverId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); // Get user ID from JWT

            // Check if the approver is a Manager
            var employeeApprover = await _employeeRepository.GetByUserId(approverId);

            // Check if the approver is HR
            var hrApprover = await _HRRepository.GetByUserId(approverId);

            if (employeeApprover == null && hrApprover == null)
            {
                return Unauthorized("Approver not found.");
            }

            // Only Managers or HR can approve leave requests
            if ((employeeApprover?.Designation.Contains("Manager") == true) || (hrApprover != null))
            {
                var result = await _leaveService.ApproveLeave(approverId, dto);
                return Ok(new { message = result });
            }

            return Unauthorized("You do not have the necessary permissions to approve leave requests.");
        }
    }
}
