using Intranet.Application.Contracts.Persistence;
using Intranet.Domain.Models;
using Intranet.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Persistence.Repositories;

public class NewsRepository : GenericRepository<News>, INewsRepository
{
    public NewsRepository(IntranetDatabaseContext context) : base(context)
    {
    }

    public async Task<List<News>> GetNewsByAuthorIdAsync(Guid authorId)
    {
        return await _context.News.Where(x => x.Author == authorId).ToListAsync();
    }

    public async Task<News> GetNewsWithAuthorDetailsByIdAsync(Guid id)
    {
        return await _context.News.Include(w => w.EmployeeDirectory).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<News>> GetTopLastestNewsAsync()
    {
        return await _context.News.OrderByDescending(x => x.DateUpdated).Take(3).ToListAsync();
    }

    public async Task<bool> IsNewsTitleUniqueAsync(string title)
    {
        return await _context.News.AnyAsync(x => x.Title == title);
    }

    public async Task<bool> NewsExistsAsync(Guid id)
    {
        return await _context.News.AnyAsync(x => x.Id == id);
    }
}
