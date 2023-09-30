namespace Intranet.Application.Features.EmployeeDirectory.Queries.GetEmployeeBirthday;

public class MonthlyEmployeeBirthdayDto
{
    public Guid Id { get; set; }
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
