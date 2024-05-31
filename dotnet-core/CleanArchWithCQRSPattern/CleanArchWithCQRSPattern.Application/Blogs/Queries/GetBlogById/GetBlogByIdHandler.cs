using AutoMapper;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using MediatR;

public class GetBlogByIdHandler : IRequestHandler<GetBlogByIdQuery, BlogsVm>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public GetBlogByIdHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<BlogsVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetByIdAsync(request.BlogId).ConfigureAwait(false);
        return _mapper.Map<BlogsVm>(blog);
    }
}