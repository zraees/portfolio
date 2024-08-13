namespace OrderProcessUsingMassTransitRabbitMq.SharedModels;

public interface IOrderCreated
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
}
