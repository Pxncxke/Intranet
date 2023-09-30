using FluentValidation;
using Intranet.Application.Contracts.Persistence;

namespace Intranet.Application.Features.EmployeeDirectory.Commands.DeleteEmployee
{
    public class DeleteEmployeeDirectoryCommandValidator : AbstractValidator<DeleteEmployeeDirectoryCommand>
    {
        private readonly IEmployeeDirectoryRepository employeeRepository;

        public DeleteEmployeeDirectoryCommandValidator(IEmployeeDirectoryRepository employeeRepository)
        {
            RuleFor(w => w.Id)
            .NotEmpty().WithMessage("{Property Name} cannot be empty")
            .NotNull().WithMessage("{Property Name} is required");

            RuleFor(w => w)
            .MustAsync(EmployeeExist)
            .WithMessage("Employee doesn't exists");
            this.employeeRepository = employeeRepository;
        }
        private async Task<bool> EmployeeExist(DeleteEmployeeDirectoryCommand command, CancellationToken cancellationToken)
        {
            return await employeeRepository.EmployeeExistsAsync(command.Id);
        }
    }
}
