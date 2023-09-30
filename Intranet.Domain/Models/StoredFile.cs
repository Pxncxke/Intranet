using Intranet.Domain.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Domain.Models;

public class StoredFile: BaseEntity
{
    public string Title { get; set; }
    public string Extension { get; set; }
    public string Filename { get; set; }
    public string StorageUrl { get; set; }
    public string Type { get; set; }
    public News News {  get; set; }
    [ForeignKey("News")]
    public Guid NewsId { get; set; }
}
