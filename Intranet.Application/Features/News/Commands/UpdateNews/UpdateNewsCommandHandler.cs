using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using Intranet.Application.Exceptions;
using MediatR;

namespace Intranet.Application.Features.News.Commands.UpdateNews;

public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly INewsRepository newsRepository;

    public UpdateNewsCommandHandler(IMapper mapper, INewsRepository newsRepository)
    {
        this.mapper = mapper;
        this.newsRepository = newsRepository;
    }
    public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateNewsCommandValidator(newsRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Invalid Operation", validationResult);
        }

        var news = mapper.Map<Domain.Models.News>(request);

        await newsRepository.UpdateAsync(news);

        return Unit.Value;
    }
}
