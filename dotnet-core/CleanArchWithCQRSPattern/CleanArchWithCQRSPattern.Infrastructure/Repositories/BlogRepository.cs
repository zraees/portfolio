using CleanArchWithCQRSPattern.Domain.Entities;

public class BlogRepository : GenericRepository<Blog>
{
    public BlogRepository(BlogDbContext blogDbContext) : base(blogDbContext)
    {

    }
}