using Intranet.Application.Contracts.Persistence;
using Intranet.Domain.Models;
using Intranet.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Persistence.Repositories;

public class EmployeeDirectoryRepository: GenericRepository<EmployeeDirectory>, IEmployeeDirectoryRepository
{
    public EmployeeDirectoryRepository(IntranetDatabaseContext context) : base(context)
    {
        
    }

    public async Task<bool> EmployeeExistsAsync(Guid id)
    { 
        return await _context.EmployeeDirectory.AnyAsync(x => x.Id == id);
    }

    public async Task<List<EmployeeDirectory>> GetMonthlyEmployeeBirthdayAsync()
    {
        return await _context.EmployeeDirectory.Where(x => x.Birthday.Value.Month == DateTime.Now.Month).ToListAsync();
    }
}
