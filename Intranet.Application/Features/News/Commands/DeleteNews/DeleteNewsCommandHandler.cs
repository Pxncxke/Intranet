using Intranet.Application.Contracts.Persistence;
using Intranet.Application.Exceptions;
using MediatR;

namespace Intranet.Application.Features.News.Commands.DeleteNews;

public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, Unit>
{
    private readonly INewsRepository newsRepository;

    public DeleteNewsCommandHandler(INewsRepository newsRepository)
    {
        this.newsRepository = newsRepository;
    }

    public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteNewsCommandValidator(newsRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new NotFoundException(nameof(News), request.Id);
        }

        var news = await newsRepository.GetByIdAsync(request.Id);

        await newsRepository.DeleteAsync(news);

        return Unit.Value;
    }
}
