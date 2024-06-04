using CleanArchWithCQRSPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Blog> Blogs { get; set; }
}