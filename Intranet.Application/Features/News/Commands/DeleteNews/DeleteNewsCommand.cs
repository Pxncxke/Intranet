using MediatR;

namespace Intranet.Application.Features.News.Commands.DeleteNews;

public class DeleteNewsCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
