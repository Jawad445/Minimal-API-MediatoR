using Application.Abstraction;
using Application.Commands;
using Domain.Model;
using MediatR;

namespace Application.CommandHandlers;

public class CreatePostHandler : IRequestHandler<CreatePost, Post>
{
    private readonly IPostRepo _postRepo;
    public CreatePostHandler(IPostRepo repo)
    {
        _postRepo = repo;
    }
    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Content = request.postContent,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        return await _postRepo.CreatePost(post);
    }
}
