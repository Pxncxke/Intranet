using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using MediatR;

namespace Intranet.Application.Features.News.Queries.GetAllNews;

public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, List<NewsDto>>
{
    private readonly IMapper mapper;
    private readonly INewsRepository newsRepository;

    public GetNewsQueryHandler(IMapper mapper, INewsRepository newsRepository)
    {
        this.mapper = mapper;
        this.newsRepository = newsRepository;
    }

    public async Task<List<NewsDto>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetAsync();

        var dto = mapper.Map<List<NewsDto>>(news);

        return dto;
    }
}
