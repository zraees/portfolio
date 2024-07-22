using FluentResults;
using MediatR;

/// <summary>
/// the GetBlogsQuery record type represents a request to retrieve a collection of BlogsVm objects 
/// (presumably a "view model" representing blog data).
/// </summary>
public record GetBlogsQuery : IRequest<Result<IEnumerable<BlogsVm>>>;
