using AutoMapper;
using Intranet.Application.Features.EmployeeDirectory.Commands.CreateEmployee;
using Intranet.Application.Features.EmployeeDirectory.Commands.UpdateEmployee;
using Intranet.Application.Features.EmployeeDirectory.Queries.GetAllEmployees;
using Intranet.Application.Features.EmployeeDirectory.Queries.GetEmployeeBirthday;
using Intranet.Application.Features.EmployeeDirectory.Queries.GetEmployeeDetails;
using Intranet.Domain.Models;

namespace Intranet.Application.MappingProfiles;

public class EmployeeDirectoryProfile : Profile
{
    public EmployeeDirectoryProfile()
    {
        CreateMap<EmployeeDirectoryDto, EmployeeDirectory>().ReverseMap();
        CreateMap<EmployeeDirectoryDetailsDto, EmployeeDirectory>().ReverseMap();
        CreateMap<MonthlyEmployeeBirthdayDto, EmployeeDirectory>().ReverseMap();
        CreateMap<CreateEmployeeDirectoryCommand, EmployeeDirectory>().ReverseMap();
        CreateMap<UpdateEmployeeDirectoryCommand, EmployeeDirectory>().ReverseMap();
    }
}
