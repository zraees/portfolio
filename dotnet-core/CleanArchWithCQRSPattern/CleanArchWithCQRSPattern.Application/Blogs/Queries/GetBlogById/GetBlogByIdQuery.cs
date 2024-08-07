using FluentResults;
using MediatR;

public record GetBlogByIdQuery(Guid BlogId) : IRequest<Result<BlogsVm>>;
