using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timesheet.Interfaces;
using Timesheet.Models.DTO;
using Timesheet.Models.DTOs;

namespace Timesheet.Controllers
{
    [ApiController]
    [Route("api/roles")]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleDto dto)
        {
            var success = await _roleService.UpdateUserRoleAsync(dto);
            if (!success)
                return NotFound("User not found");

            return Ok("User role updated successfully");
        }
    }
}

