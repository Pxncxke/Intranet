using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Queries.GetEmployeeDetails;

public class GetEmployeeDirectoryDetailsQueryHandler : IRequestHandler<GetEmployeeDirectoryDetailsQuery, EmployeeDirectoryDetailsDto>
{
    private readonly IMapper mapper;
    private readonly IEmployeeDirectoryRepository employeeRepository;

    public GetEmployeeDirectoryDetailsQueryHandler(IMapper mapper, IEmployeeDirectoryRepository employeeRepository)
    {
        this.mapper = mapper;
        this.employeeRepository = employeeRepository;
    }
    public async Task<EmployeeDirectoryDetailsDto> Handle(GetEmployeeDirectoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.Id);

        var dto = mapper.Map<EmployeeDirectoryDetailsDto>(employee);

        return dto;
    }
}
