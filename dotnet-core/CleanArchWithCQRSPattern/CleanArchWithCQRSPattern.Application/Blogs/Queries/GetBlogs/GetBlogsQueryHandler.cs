using MediatR;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;

public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, IEnumerable<BlogsVm>>
{
    private readonly IBlogRepository _blogRepository;

    public GetBlogsQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    public async Task<IEnumerable<BlogsVm>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _blogRepository.GetAllAsync().ConfigureAwait(false);
        return blogs.Select(b => new BlogsVm() { Id = b.Id, Name = b.Name, Description = b.Description, Author = b.Author });
    }
}