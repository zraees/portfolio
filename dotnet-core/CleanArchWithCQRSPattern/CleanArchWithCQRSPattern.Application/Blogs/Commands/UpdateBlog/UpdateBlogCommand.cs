using MediatR;

public record UpdateBlogCommand(Guid id, string name, string description, string author) : IRequest<Guid>;