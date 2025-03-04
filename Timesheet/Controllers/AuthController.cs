using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Interfaces;
using Timesheet.Models.DTO;
using System;
using System.Threading.Tasks;

namespace Timesheet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }


        [HttpPost("register")]
        [AllowAnonymous] 
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userregistrationDto)
        {
            try
            {
                var userResponse = await _authService.RegisterAsync(userregistrationDto);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Register: {ex}"); 
                return BadRequest(new { error = "Registration failed. Please try again later." });
            }
        }


        [HttpPost("login")]
        [AllowAnonymous] 
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var response = await _authService.LoginAsync(loginDto);

                if (response == null)
                    return Unauthorized(new { error = "Invalid email or password" }); 

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Login: {ex}"); 
                return BadRequest(new { error = "Login failed. Please try again later." });
            }
        }
    }
}


