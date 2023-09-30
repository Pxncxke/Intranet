using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Queries.GetAllEmployees;

public class GetEmployeeDirectoryQuery : IRequest<List<EmployeeDirectoryDto>>
{
}
