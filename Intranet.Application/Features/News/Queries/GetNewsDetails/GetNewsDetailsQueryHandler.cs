using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using MediatR;

namespace Intranet.Application.Features.News.Queries.GetNewsDetails;

public class GetNewsDetailsQueryHandler : IRequestHandler<GetNewsDetailsQuery, NewsDetailsDto>
{
    private readonly IMapper mapper;
    private readonly INewsRepository newsRepository;

    public GetNewsDetailsQueryHandler(IMapper mapper, INewsRepository newsRepository)
    {
        this.mapper = mapper;
        this.newsRepository = newsRepository;
    }
    public async Task<NewsDetailsDto> Handle(GetNewsDetailsQuery request, CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetByIdAsync(request.Id);

        var dto = mapper.Map<NewsDetailsDto>(news);

        return dto;
    }
}
