using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Queries.GetAllEmployees;

public class GetEmployeeDirectoryQueryHandler : IRequestHandler<GetEmployeeDirectoryQuery, List<EmployeeDirectoryDto>>
{
    private readonly IMapper mapper;
    private readonly IEmployeeDirectoryRepository employeeRepository;

    public GetEmployeeDirectoryQueryHandler(IMapper mapper, IEmployeeDirectoryRepository employeeRepository)
    {
        this.mapper = mapper;
        this.employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeeDirectoryDto>> Handle(GetEmployeeDirectoryQuery request, CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.GetAsync();

        var dto = mapper.Map<List<EmployeeDirectoryDto>>(employees);

        return dto;
    }
}
