using Timesheet.Models.DTO;

namespace Timesheet.Interfaces
{
    public interface IRoleService
    {
        Task<bool> UpdateUserRoleAsync(UpdateUserRoleDto dto);
    }
}




