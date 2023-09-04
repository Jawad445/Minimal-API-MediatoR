using Domain.Model;
using MediatR;

namespace Application.Queries;

public class GetPosts : IRequest<ICollection<Post>>
{

}
