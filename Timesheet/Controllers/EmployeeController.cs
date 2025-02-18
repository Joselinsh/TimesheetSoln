using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Interfaces;
using Timesheet.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Timesheet.Service;
using Timesheet.Models.DTO;

namespace Timesheet.Controllers
{
    [Route("api/employee")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly ILeaveService _leaveService;

        public EmployeeController(IEmployeeRepository employeeRepository, ITimesheetRepository timesheetRepository, ILeaveService leaveService)
        {
            _employeeRepository = employeeRepository;
            _timesheetRepository = timesheetRepository;
            _leaveService = leaveService;
        }


        [HttpGet("profile/{employeeId}")]
        public async Task<IActionResult> GetEmployeeProfile(int employeeId)
        {
            var employee = await _employeeRepository.GetByEmployeeId(employeeId);

            if (employee == null)
                return NotFound("Employee not found.");

            return Ok(new
            {
                employee.Id,
                employee.UserId,
                employee.FullName,
                employee.Email,
                employee.Department,
                employee.Designation,
                Timesheets = employee.Timesheets.Select(t => new
                {
                    t.Id,
                    t.ProjectName,
                    t.Date,
                    t.HoursWorked,
                    t.Description,
                    Status = t.Status.ToString()
                }).ToList()
            });
        }




        [HttpGet("timesheets/{employeeId}")]
        public async Task<IActionResult> GetEmployeeTimesheets(int employeeId)
        {
            var timesheets = await _timesheetRepository.GetTimesheetsByEmployeeId(employeeId);

            if (timesheets == null || timesheets.Count == 0)
                return NotFound("No timesheets found for this employee.");

            return Ok(timesheets.Select(t => new
            {
                t.Id,
                t.ProjectName,
                t.Date,
                t.HoursWorked,
                t.Description,
                Status = t.Status.ToString()
            }));
        }
        [HttpGet("leaves")]
        public async Task<IActionResult> GetEmployeeLeaves(int employeeId)
        {
            var leaves = await _leaveService.GetEmployeeLeaves(employeeId);

            if (leaves == null || leaves.Count == 0)
                return NotFound("No leave requests found for this employee.");
            return Ok(leaves.Select(l => new
            {
                l.Id,
                l.StartDate,
                l.EndDate,

                Status = l.Status.ToString()
            }));
        }
        [HttpPut("update/{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeProfile(int employeeId, [FromBody] UpdateEmployeeDto dto)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployeeProfile(employeeId, dto);
            if (updatedEmployee == null)
                return NotFound("Employee not found.");

            return Ok(new
            {
                updatedEmployee.Id,
                updatedEmployee.FullName,
                updatedEmployee.Email,
                updatedEmployee.Department,
                updatedEmployee.Designation
            });
        }
    }
}



    

