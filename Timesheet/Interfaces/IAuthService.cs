using Timesheet.Models.DTO;

using System.Threading.Tasks;

namespace Timesheet.Interfaces
{
    public interface IAuthService
    {
        Task<UserRegistrationResponseDto> RegisterAsync(UserRegistrationDto userregistrationDto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    }
}
