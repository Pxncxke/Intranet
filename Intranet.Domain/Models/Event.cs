using Intranet.Domain.Models.Common;

namespace Intranet.Domain.Models;

public class Event: BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Location { get; set; }
    public DateTime EventDate { get; set; }
}
