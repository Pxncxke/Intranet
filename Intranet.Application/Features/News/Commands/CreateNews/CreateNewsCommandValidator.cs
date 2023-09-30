using FluentValidation;
using Intranet.Application.Contracts.Persistence;

namespace Intranet.Application.Features.News.Commands.CreateNews;

public class CreateNewsCommandValidator: AbstractValidator<CreateNewsCommand>
{
    private readonly INewsRepository newsRepository;

    public CreateNewsCommandValidator(INewsRepository newsRepository)
    {
        RuleFor(w => w.Author)
            .NotEmpty().WithMessage("{Property Name} cannot be empty")
            .NotNull().WithMessage("{Property Name} is required");

        RuleFor(w => w.Title)
            .NotEmpty().WithMessage("{Property Name} cannot be empty")
            .NotNull().WithMessage("{Property Name} is required");

        RuleFor(w => w.Content)
            .NotEmpty().WithMessage("{Property Name} cannot be empty")
            .NotNull().WithMessage("{Property Name} is required");

        RuleFor(w => w)
            .MustAsync(NewsTitleUnique)
            .WithMessage("Title already exists");

        this.newsRepository = newsRepository;
    }

    private async Task<bool> NewsTitleUnique(CreateNewsCommand command, CancellationToken cancellationToken)
    {
        return !await newsRepository.IsNewsTitleUniqueAsync(command.Title);
    }
}
