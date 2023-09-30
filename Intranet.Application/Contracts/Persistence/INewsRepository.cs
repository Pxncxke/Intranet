using Intranet.Domain.Models;

namespace Intranet.Application.Contracts.Persistence;

public interface INewsRepository : IGenericRepository<News>
{
    Task<List<News>> GetNewsByAuthorIdAsync(Guid authorId);
    Task<News> GetNewsWithAuthorDetailsByIdAsync(Guid id);
    Task<List<News>> GetTopLastestNewsAsync();
    Task<bool> IsNewsTitleUniqueAsync(string title);
    Task<bool> NewsExistsAsync(Guid id);
}
