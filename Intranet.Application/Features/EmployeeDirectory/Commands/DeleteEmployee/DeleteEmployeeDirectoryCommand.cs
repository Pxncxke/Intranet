using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Commands.DeleteEmployee
{
    public class DeleteEmployeeDirectoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
