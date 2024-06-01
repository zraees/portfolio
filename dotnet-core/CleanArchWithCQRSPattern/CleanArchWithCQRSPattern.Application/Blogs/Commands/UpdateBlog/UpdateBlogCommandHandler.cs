using CleanArchWithCQRSPattern.Domain.Entities;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using MediatR;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;

    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = new Blog { Id = request.id, Name = request.name, Description = request.description, Author = request.author };
        return await _blogRepository.UpdateAsync(request.id, blog).ConfigureAwait(false);
    }
}