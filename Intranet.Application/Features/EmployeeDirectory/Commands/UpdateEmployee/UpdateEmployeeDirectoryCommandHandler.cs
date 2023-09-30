using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using Intranet.Application.Exceptions;
using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Commands.UpdateEmployee
{
    public class UpdateEmployeeDirectoryCommandHandler : IRequestHandler<UpdateEmployeeDirectoryCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeDirectoryRepository employeeRepository;

        public UpdateEmployeeDirectoryCommandHandler(IMapper mapper, IEmployeeDirectoryRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(UpdateEmployeeDirectoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEmployeeDirectoryCommandValidator(employeeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Operation", validationResult);
            }

            var employee = mapper.Map<Domain.Models.EmployeeDirectory>(request);

            await employeeRepository.UpdateAsync(employee);

            return Unit.Value;
        }
    }
}
