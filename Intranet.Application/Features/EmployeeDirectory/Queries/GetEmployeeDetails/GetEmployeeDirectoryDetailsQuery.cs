using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Queries.GetEmployeeDetails;

public record GetEmployeeDirectoryDetailsQuery(Guid Id) : IRequest<EmployeeDirectoryDetailsDto>
{
}
