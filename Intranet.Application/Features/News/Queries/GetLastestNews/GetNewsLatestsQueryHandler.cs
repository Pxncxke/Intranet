using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using MediatR;

namespace Intranet.Application.Features.News.Queries.GetLatestNews;

public class GetNewsLatestsQueryHandler : IRequestHandler<GetNewsLatestQuery, List<NewsLatestDto>>
{
    private readonly IMapper mapper;
    private readonly INewsRepository newsRepository;

    public GetNewsLatestsQueryHandler(IMapper mapper, INewsRepository newsRepository)
    {
        this.mapper = mapper;
        this.newsRepository = newsRepository;
    }
    public async Task<List<NewsLatestDto>> Handle(GetNewsLatestQuery request, CancellationToken cancellationToken)
    {
        var topNews = await newsRepository.GetTopLastestNewsAsync();

        var dto = mapper.Map<List<NewsLatestDto>>(topNews);

        return dto;
    }
}
