namespace CleanArchWithCQRSPattern.Domain.Entities;

public class Blog : BaseEntity
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Author { get; set; }
}