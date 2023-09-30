using Intranet.Domain.Models;

namespace Intranet.Application.Contracts.Persistence;

public interface IEmployeeDirectoryRepository : IGenericRepository<EmployeeDirectory>
{
    Task<List<EmployeeDirectory>> GetMonthlyEmployeeBirthdayAsync();
    Task<bool> EmployeeExistsAsync(Guid id);
}
