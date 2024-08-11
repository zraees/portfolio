using System.ComponentModel.DataAnnotations;

namespace Publisher.Data;

public class Order
{
    public int Id { get; set; }

    [MaxLength(250)]
    public required string ProductName { get; set; }

    [Range(0, 999)]
    public double Price { get; set; }

    [Range(0,9999)]
    public int Quantity { get; set; }
}
