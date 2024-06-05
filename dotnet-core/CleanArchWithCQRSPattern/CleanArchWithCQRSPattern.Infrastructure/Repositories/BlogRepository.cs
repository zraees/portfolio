using CleanArchWithCQRSPattern.Domain.Entities;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(BlogDbContext blogDbContext) : base(blogDbContext)
    {

    }
}