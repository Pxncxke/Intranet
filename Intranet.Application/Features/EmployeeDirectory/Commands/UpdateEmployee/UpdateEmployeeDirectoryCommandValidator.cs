using FluentValidation;
using Intranet.Application.Contracts.Persistence;

namespace Intranet.Application.Features.EmployeeDirectory.Commands.UpdateEmployee
{
    public class UpdateEmployeeDirectoryCommandValidator : AbstractValidator<UpdateEmployeeDirectoryCommand>
    {
        private readonly IEmployeeDirectoryRepository employeeRepository;

        public UpdateEmployeeDirectoryCommandValidator(IEmployeeDirectoryRepository employeeRepository)
        {
            RuleFor(w => w.Id)
            .NotEmpty().WithMessage("{Property Name} cannot be empty")
            .NotNull().WithMessage("{Property Name} is required");

            RuleFor(w => w.FirstName)
            .NotEmpty().WithMessage("{Property Name} cannot be empty")
            .NotNull().WithMessage("{Property Name} is required");

            RuleFor(w => w.LastName)
                .NotEmpty().WithMessage("{Property Name} cannot be empty")
                .NotNull().WithMessage("{Property Name} is required");

            RuleFor(w => w.Birthday)
                .NotEmpty().WithMessage("{Property Name} cannot be empty")
                .NotNull().WithMessage("{Property Name} is required");

            RuleFor(w => w)
             .MustAsync(EmployeeExist)
             .WithMessage("Employee doesn't exists");

            this.employeeRepository = employeeRepository;
        }

        private async Task<bool> EmployeeExist(UpdateEmployeeDirectoryCommand command, CancellationToken cancellationToken)
        {
            return await employeeRepository.EmployeeExistsAsync(command.Id);
        }
    }
}
