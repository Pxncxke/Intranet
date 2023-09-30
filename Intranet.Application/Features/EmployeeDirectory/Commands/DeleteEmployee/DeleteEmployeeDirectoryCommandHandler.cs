using Intranet.Application.Contracts.Persistence;
using Intranet.Application.Exceptions;
using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Commands.DeleteEmployee
{
    public class DeleteEmployeeDirectoryCommandHandler : IRequestHandler<DeleteEmployeeDirectoryCommand, Unit>
    {
        private readonly IEmployeeDirectoryRepository employeeRepository;

        public DeleteEmployeeDirectoryCommandHandler(IEmployeeDirectoryRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(DeleteEmployeeDirectoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteEmployeeDirectoryCommandValidator(employeeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new NotFoundException(nameof(EmployeeDirectory), request.Id);
            }

            var news = await employeeRepository.GetByIdAsync(request.Id);

            await employeeRepository.DeleteAsync(news);

            return Unit.Value;
        }
    }
}
