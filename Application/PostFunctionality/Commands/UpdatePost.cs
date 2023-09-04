using Domain.Model;
using MediatR;

namespace Application.Commands;

public class UpdatePost : IRequest<Post>
{
    public int postId { get; set; }
    public string content { get; set; }
}
