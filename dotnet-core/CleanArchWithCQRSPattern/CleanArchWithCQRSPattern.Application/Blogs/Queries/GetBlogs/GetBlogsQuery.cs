using MediatR;

public record GetBlogsQuery: IRequest<IEnumerable<BlogsVm>>;
