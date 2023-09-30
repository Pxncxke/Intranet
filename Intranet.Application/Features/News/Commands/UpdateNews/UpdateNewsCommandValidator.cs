using FluentValidation;
using Intranet.Application.Contracts.Persistence;

namespace Intranet.Application.Features.News.Commands.UpdateNews;

public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
{
    private readonly INewsRepository newsRepository;

    public UpdateNewsCommandValidator(INewsRepository newsRepository)
    {
        RuleFor(w => w.Id)
         .NotEmpty().WithMessage("{Property Name} cannot be empty")
         .NotNull().WithMessage("{Property Name} is required");

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
         .MustAsync(NewsExist)
         .WithMessage("News doesn't exists");
        this.newsRepository = newsRepository;
    }

    private async Task<bool> NewsExist(UpdateNewsCommand command, CancellationToken cancellationToken)
    {
        return await newsRepository.NewsExistsAsync(command.Id);
    }
}
