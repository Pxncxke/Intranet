using MediatR;

namespace Intranet.Application.Features.News.Queries.GetNewsDetails;

public record GetNewsDetailsQuery(Guid Id) : IRequest<NewsDetailsDto>
{
}
