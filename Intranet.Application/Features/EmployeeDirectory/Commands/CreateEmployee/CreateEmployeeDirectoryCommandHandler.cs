using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using Intranet.Application.Exceptions;
using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Commands.CreateEmployee
{
    public class CreateEmployeeDirectoryCommandHandler : IRequestHandler<CreateEmployeeDirectoryCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeDirectoryRepository employeeRepository;

        public CreateEmployeeDirectoryCommandHandler(IMapper mapper, IEmployeeDirectoryRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }
        public async Task<Unit> Handle(CreateEmployeeDirectoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEmployeeDirectoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Operation", validationResult);
            }

            var employee = mapper.Map<Domain.Models.EmployeeDirectory>(request);

            await employeeRepository.CreateAsync(employee);

            return Unit.Value;
        }
    }
}
