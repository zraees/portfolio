using MediatR;

public record GetBlogByIdQuery(Guid BlogId) : IRequest<BlogsVm>;