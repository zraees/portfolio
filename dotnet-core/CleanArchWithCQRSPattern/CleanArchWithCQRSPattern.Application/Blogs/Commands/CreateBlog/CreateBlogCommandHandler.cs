using AutoMapper;
using CleanArchWithCQRSPattern.Domain.Entities;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using MediatR;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogsVm>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<BlogsVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = new Blog()
        {
            Name = request.name,
            Description = request.description,
            Author = request.author
        };

        await _blogRepository.CreateAsync(blog).ConfigureAwait(false);

        return _mapper.Map<BlogsVm>(await _blogRepository.GetByIdAsync(blog.Id).ConfigureAwait(false));
    }
}