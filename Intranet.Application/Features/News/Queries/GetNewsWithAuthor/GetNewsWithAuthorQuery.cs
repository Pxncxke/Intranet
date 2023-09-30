using MediatR;

namespace Intranet.Application.Features.News.Queries.GetNewsWithAuthor;

public record GetNewsWithAuthorQuery(Guid Id) : IRequest<NewsWithAuthorDto>
{
}
