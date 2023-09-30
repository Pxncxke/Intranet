using AutoMapper;
using Intranet.Application.Features.News.Commands.CreateNews;
using Intranet.Application.Features.News.Commands.UpdateNews;
using Intranet.Application.Features.News.Queries.GetAllNews;
using Intranet.Application.Features.News.Queries.GetLatestNews;
using Intranet.Application.Features.News.Queries.GetNewsDetails;
using Intranet.Application.Features.News.Queries.GetNewsWithAuthor;
using Intranet.Domain.Models;

namespace Intranet.Application.MappingProfiles;

public class NewsProfile: Profile
{
    public NewsProfile()
    {
        CreateMap<NewsDto, News>().ReverseMap();
        CreateMap<NewsDetailsDto, News>().ReverseMap();
        CreateMap<NewsWithAuthorDto, News>().ReverseMap();
        CreateMap<NewsLatestDto, News>().ReverseMap();
        CreateMap<CreateNewsCommand, News>().ReverseMap();
        CreateMap<UpdateNewsCommand, News>().ReverseMap();
    }
}
