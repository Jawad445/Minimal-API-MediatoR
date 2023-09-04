using Application.Abstraction;
using Application.Queries;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryHandlers;

public class GetPostsHandler : IRequestHandler<GetPosts, ICollection<Post>>
{
    private readonly IPostRepo _repo;
    public GetPostsHandler(IPostRepo postRepo)
    {
        _repo = postRepo;
    }

    public async Task<ICollection<Post>> Handle(GetPosts request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllPosts();
    }
}
