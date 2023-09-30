using FluentValidation;
using Intranet.Application.Contracts.Persistence;

namespace Intranet.Application.Features.News.Commands.DeleteNews;

public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
{
    private readonly INewsRepository newsRepository;

    public DeleteNewsCommandValidator(INewsRepository newsRepository)
    {
        RuleFor(w => w.Id)
        .NotEmpty().WithMessage("{Property Name} cannot be empty")
        .NotNull().WithMessage("{Property Name} is required");

        RuleFor(w => w)
        .MustAsync(NewsExist)
        .WithMessage("News doesn't exists");

        this.newsRepository = newsRepository;
    }

    private async Task<bool> NewsExist(DeleteNewsCommand command, CancellationToken cancellationToken)
    {
        return await newsRepository.NewsExistsAsync(command.Id);
    }
}
