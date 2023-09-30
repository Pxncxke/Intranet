using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using Intranet.Application.Exceptions;
using MediatR;

namespace Intranet.Application.Features.News.Commands.CreateNews;

public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly INewsRepository newsRepository;

    public CreateNewsCommandHandler(IMapper mapper, INewsRepository newsRepository)
    {
        this.mapper = mapper;
        this.newsRepository = newsRepository;
    }
    public async Task<Unit> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
        //validate
        var validator = new CreateNewsCommandValidator(newsRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Invalid Operation", validationResult);
        }

        var news = mapper.Map<Domain.Models.News>(request);

        await newsRepository.CreateAsync(news);

        return Unit.Value;
    }
}
