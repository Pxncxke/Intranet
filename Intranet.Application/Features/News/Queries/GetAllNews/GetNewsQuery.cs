using MediatR;

namespace Intranet.Application.Features.News.Queries.GetAllNews;

public record GetNewsQuery : IRequest<List<NewsDto>>
{
}
