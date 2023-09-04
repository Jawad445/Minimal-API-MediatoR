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

public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
{
    private readonly IPostRepo _repo;
    public GetPostByIdHandler(IPostRepo postRepo)
    {
        _repo = postRepo;
    }

    public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
    {
        return await _repo.GetPostById(request.Id);
    }
}
