using Intranet.Domain.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Domain.Models;

public class News: BaseEntity
{
    public string Title { get; set; }
    public string Content {  get; set; }
    public EmployeeDirectory EmployeeDirectory { get; set; }
    [ForeignKey("EmployeeDirectory")]
    public Guid Author {  get; set; }
    public bool IsActive { get; set; }
}
