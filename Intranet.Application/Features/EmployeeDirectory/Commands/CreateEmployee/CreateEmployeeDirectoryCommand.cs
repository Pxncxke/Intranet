using MediatR;

namespace Intranet.Application.Features.EmployeeDirectory.Commands.CreateEmployee
{
    public class CreateEmployeeDirectoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Building { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string Region { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
