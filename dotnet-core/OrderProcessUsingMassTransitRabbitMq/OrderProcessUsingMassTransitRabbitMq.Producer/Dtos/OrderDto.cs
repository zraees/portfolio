namespace OrderProcessUsingMassTransitRabbitMq.Producer.Dtos;

public class OrderDto
{
    public required string ProductName { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }
}
