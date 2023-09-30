using FluentValidation;

namespace Intranet.Application.Features.EmployeeDirectory.Commands.CreateEmployee
{
    public class CreateEmployeeDirectoryCommandValidator : AbstractValidator<CreateEmployeeDirectoryCommand>
    {
        public CreateEmployeeDirectoryCommandValidator()
        {
            RuleFor(w => w.FirstName)
           .NotEmpty().WithMessage("{Property Name} cannot be empty")
           .NotNull().WithMessage("{Property Name} is required");

            RuleFor(w => w.LastName)
                .NotEmpty().WithMessage("{Property Name} cannot be empty")
                .NotNull().WithMessage("{Property Name} is required");

            RuleFor(w => w.Birthday)
                .NotEmpty().WithMessage("{Property Name} cannot be empty")
                .NotNull().WithMessage("{Property Name} is required");
        }
    }
}
