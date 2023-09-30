using AutoMapper;
using Intranet.Application.Contracts.Persistence;
using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Queries.GetEmployeeBirthday;

public class GetMonthlyEmployeeBirthdayQueryHandler : IRequestHandler<GetMonthlyEmployeeBirthdayQuery, List<MonthlyEmployeeBirthdayDto>>
{
    private readonly IMapper mapper;
    private readonly IEmployeeDirectoryRepository employeeRepository;

    public GetMonthlyEmployeeBirthdayQueryHandler(IMapper mapper, IEmployeeDirectoryRepository employeeRepository)
    {
        this.mapper = mapper;
        this.employeeRepository = employeeRepository;
    }
    public async Task<List<MonthlyEmployeeBirthdayDto>> Handle(GetMonthlyEmployeeBirthdayQuery request, CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.GetMonthlyEmployeeBirthdayAsync();

        var dto = mapper.Map<List<MonthlyEmployeeBirthdayDto>>(employees);

        return dto;
    }
}
