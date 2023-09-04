using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction;

public interface IPostRepo
{
    Task<Post> CreatePost(Post post);
    Task<ICollection<Post>> GetAllPosts();
    Task<Post> UpdatePost(string content, int postId);
    Task<Post> GetPostById(int id);
    Task DeletePost(int id);

}
