using AutoMapper;
using CleanArchWithCQRSPattern.Application.Common.Exceptions.Errors;
using CleanArchWithCQRSPattern.Domain.Entities;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<BlogsVm>>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<Result<BlogsVm>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        // some validation to show how to use result pattern
        if (request.name.Contains("blog"))
        {
            return new ValidationError("the word 'blog' is not allowed in name");
        }

        var blog = new Blog()
        {
            Name = request.name,
            Description = request.description,
            Author = request.author
        };

        await _blogRepository.CreateAsync(blog).ConfigureAwait(false);

        return Result.Ok(_mapper.Map<BlogsVm>(await _blogRepository.GetByIdAsync(blog.Id).ConfigureAwait(false)));
    }
}
