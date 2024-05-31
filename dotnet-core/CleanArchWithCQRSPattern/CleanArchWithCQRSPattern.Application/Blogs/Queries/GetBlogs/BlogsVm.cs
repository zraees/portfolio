using CleanArchWithCQRSPattern.Domain.Entities;

public class BlogsVm : IMapFrom<Blog>
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Author { get; set; }
}