using MediatR;

namespace Intranet.Application.Features.News.Commands.CreateNews;

public class CreateNewsCommand: IRequest<Unit>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid Author { get; set; }
    public bool IsActive { get; set; } = true;
}
