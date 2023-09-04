using Domain.Model;
using MediatR;

namespace Application.Queries;

public class GetPostById : IRequest<Post>
{
    public int Id { get; set; }
}
