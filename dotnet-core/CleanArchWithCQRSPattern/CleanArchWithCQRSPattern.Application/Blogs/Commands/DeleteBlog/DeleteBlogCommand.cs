using MediatR;

public record DeleteBlogCommand(Guid id) : IRequest<Guid>;