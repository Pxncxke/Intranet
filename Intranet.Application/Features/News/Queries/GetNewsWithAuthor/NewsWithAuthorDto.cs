
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Application.Features.News.Queries.GetNewsWithAuthor;

public class NewsWithAuthorDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public EmployeeDirectoryDto EmployeeDirectory { get; set; }
    [ForeignKey(nameof(EmployeeDirectory))]
    public Guid Author { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
