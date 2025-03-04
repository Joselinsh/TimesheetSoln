using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheet.Interfaces;
using Timesheet.Models;

[Route("api/admin")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IUserService _userService;

    public AdminController(IUserService userService)
    {
        _userService = userService;
    }

    // ✅ Get all users
    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    // ✅ Get user by ID
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        return user == null ? NotFound("User not found.") : Ok(user);
    }

    // ✅ Get users by role
    [HttpGet("users/role/{role}")]
    public async Task<IActionResult> GetUsersByRole(string role)
    {
        var users = await _userService.GetUsersByRoleAsync(role);
        return Ok(users);
    }


    // ✅ Add a new user
    [HttpPost("user/add")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        await _userService.AddUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = user.Id }, user);
    }



    // ✅ Update user details
    [HttpPut("user/update/{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, [FromBody] User user)
    {
        var existingUser = await _userService.GetUserByIdAsync(userId);
        if (existingUser == null)
            return NotFound("User not found.");

        user.Id = userId;
        await _userService.UpdateUserAsync(user);
        return Ok(new { message = "User updated successfully!" });
    }

    // ✅ Delete user
    [HttpDelete("user/delete/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        if (user == null)
            return NotFound("User not found.");

        await _userService.DeleteUserAsync(userId);
        return Ok(new { message = "User deleted successfully!" });
    }
}
