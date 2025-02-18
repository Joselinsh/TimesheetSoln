using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Interfaces;
using Timesheet.Models.DTO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Timesheet.Controllers
{
    [Route("api/leaves/submit")]
    [ApiController]
    public class LeaveSubmissionController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeaveSubmissionController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> SubmitLeave([FromBody] SubmitLeaveDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); // Get user ID from JWT
            var result = await _leaveService.SubmitLeaveRequest(dto, userId);
            return Ok(new { message = "Leave request submitted successfully!", data = result });
        }



    }
}
