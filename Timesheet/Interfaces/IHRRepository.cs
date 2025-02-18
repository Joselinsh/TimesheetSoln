using Timesheet.Models;

namespace Timesheet.Interfaces
{
    public interface IHRRepository
    {
        Task<HR> GetByUserId(int userId);
    }
}
