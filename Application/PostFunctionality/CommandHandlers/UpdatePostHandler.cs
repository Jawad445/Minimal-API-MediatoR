using Application.Abstraction;
using Application.Commands;
using Domain.Model;
using MediatR;

namespace Application.CommandHandlers;

public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
{
    private readonly IPostRepo _postRepo;
    public UpdatePostHandler(IPostRepo repo)
    {
        _postRepo = repo;
    }
    public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        return await _postRepo.UpdatePost(request.content, request.postId); 
    }
}
