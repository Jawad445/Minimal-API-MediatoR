using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace DataAccess;

public class SocialDbContext : DbContext
{
    public SocialDbContext(DbContextOptions opt): base(opt)
    {
            
    }

    public DbSet<Post> posts { get; set; }

}