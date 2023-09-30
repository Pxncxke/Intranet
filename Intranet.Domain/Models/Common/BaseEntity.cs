namespace Intranet.Domain.Models.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
