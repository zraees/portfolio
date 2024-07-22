using MediatR;
using CleanArchWithCQRSPattern.Domain.Interfaces.Repositories;
using AutoMapper;
using FluentResults;

public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, Result<IEnumerable<BlogsVm>>>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public GetBlogsQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// The purpose of this method is to handle the GetBlogsQuery request and 
    /// return an IEnumerable<BlogsVm> (a collection of BlogsVm objects) as the response.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<IEnumerable<BlogsVm>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        //ConfigureAwait(false) is a way to optimize the performance of asynchronous code 
        //by telling the program not to worry about the specific "context" it was running in before 
        //the asynchronous operation started. This can help avoid potential issues and make the code run more smoothly.
        var blogs = await _blogRepository.GetAllAsync().ConfigureAwait(false);

        /* manually mapping entity to VM
        return blogs.Select(b => new BlogsVm() { Id = b.Id, Name = b.Name, Description = b.Description, Author = b.Author });
        */

        // mapping entity to VM using AutoMapper
        var blogList = _mapper.Map<IEnumerable<BlogsVm>>(blogs);

        return Result.Ok(blogList);
    }
}
