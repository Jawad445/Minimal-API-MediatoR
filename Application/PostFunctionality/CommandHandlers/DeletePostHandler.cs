using Application.Abstraction;
using Application.Commands;
using MediatR;

namespace Application.CommandHandlers;
public class DeletePostHandler : IRequestHandler<DeletePost>
{
    private readonly IPostRepo _repo;
    public DeletePostHandler(IPostRepo repo)
    {
        _repo = repo;
    }

    public Task Handle(DeletePost request, CancellationToken cancellationToken)
    {
        return _repo.DeletePost(request.postId);
    }
}
