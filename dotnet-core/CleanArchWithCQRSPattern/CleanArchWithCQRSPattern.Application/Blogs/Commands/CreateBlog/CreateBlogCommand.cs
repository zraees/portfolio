using FluentResults;
using MediatR;

public record CreateBlogCommand(string name, string description, string author) : IRequest<Result<BlogsVm>>;
