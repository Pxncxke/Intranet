using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using MediatR;

namespace Intranet.Application.Features.News.Queries.GetNewsWithAuthor;

public class GetNewsWithAuthorQueryHandler : IRequestHandler<GetNewsWithAuthorQuery, NewsWithAuthorDto>
{
    private readonly IMapper mapper;
    private readonly INewsRepository newsRepository;

    public GetNewsWithAuthorQueryHandler(IMapper mapper, INewsRepository newsRepository)
    {
        this.mapper = mapper;
        this.newsRepository = newsRepository;
    }
    public async Task<NewsWithAuthorDto> Handle(GetNewsWithAuthorQuery request, CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetNewsWithAuthorDetailsByIdAsync(request.Id);

        var dto = mapper.Map<NewsWithAuthorDto>(news);

        return dto;
    }
}
