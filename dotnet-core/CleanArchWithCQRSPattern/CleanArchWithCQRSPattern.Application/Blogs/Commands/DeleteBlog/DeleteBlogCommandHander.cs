using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using MediatR;

public class DeleteBlogCommandHander : IRequestHandler<DeleteBlogCommand, Guid>
{
    private readonly IBlogRepository _blogRepository;

    public DeleteBlogCommandHander(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Guid> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        return await _blogRepository.DeleteAsync(request.id).ConfigureAwait(false);
    }
}