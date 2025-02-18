using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Interfaces;
using Timesheet.Models.DTO;
using Timesheet.Models;
using System.Security.Claims;

namespace Timesheet.Controllers
{
    [Route("api/timesheets")]
    [ApiController]
    public class TimesheetSubmissionController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;

        public TimesheetSubmissionController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        [HttpPost("submit")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> SubmitTimesheet([FromBody] SubmitTimesheetDto dto)
        {
           
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);// Get user ID from JWT
            var result = await _timesheetService.SubmitTimesheet(dto, userId);
            return Ok(new { message = "Timesheet submitted successfully!", data = result });
        }
    }

}
