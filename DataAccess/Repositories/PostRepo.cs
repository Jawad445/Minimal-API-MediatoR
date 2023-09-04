using Application.Abstraction;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class PostRepo : IPostRepo
{
    private readonly SocialDbContext _context;

    public PostRepo(SocialDbContext context)
    {
        _context = context;
    }

    public async Task<Post> CreatePost(Post post)
    {
        post.CreatedAt = DateTime.Now;
        post.UpdatedAt = DateTime.Now;
        _context.posts.Add(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task DeletePost(int id)
    {
        var post = await _context.posts.FindAsync(id);
        if (post != null)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }
        else
            return;
    }

    public async Task<ICollection<Post>> GetAllPosts()
    {
        return await _context.posts.ToListAsync();
    }

    public async Task<Post> GetPostById(int id)
    {
        return await _context.posts.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<Post> UpdatePost(string content, int postId)
    {
        var post = await _context.posts.FindAsync(postId);
        if(post is not null)
        {
            post.UpdatedAt = DateTime.Now;
            post.Content = content;
            await _context.SaveChangesAsync();
            return post;
        }
        return null;
    }
}
