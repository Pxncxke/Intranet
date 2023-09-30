using MediatR;

namespace Intranet.Application.Features.News.Commands.UpdateNews;

public class UpdateNewsCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid Author { get; set; }
    public bool IsActive { get; set; }
}
