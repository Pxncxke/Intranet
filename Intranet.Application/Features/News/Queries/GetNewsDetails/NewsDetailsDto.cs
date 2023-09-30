namespace Intranet.Application.Features.News.Queries.GetNewsDetails;

public class NewsDetailsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid Author { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
