using AutoMapper;
using CleanArchWithCQRSPattern.Application.Common.Exceptions.Errors;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, Result<BlogsVm>>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<Result<BlogsVm>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetByIdAsync(request.BlogId).ConfigureAwait(false);

        if (blog == null) {
            return new RecordNotFoundError($"Blog with id {request.BlogId} is not found");
        }

        return Result.Ok(_mapper.Map<BlogsVm>(blog));
    }
}
