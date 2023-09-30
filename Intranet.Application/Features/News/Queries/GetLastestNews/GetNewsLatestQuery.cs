using MediatR;

namespace Intranet.Application.Features.News.Queries.GetLatestNews;

public record GetNewsLatestQuery : IRequest<List<NewsLatestDto>>
{
}
