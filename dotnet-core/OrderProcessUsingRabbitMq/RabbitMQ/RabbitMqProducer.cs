using OrderProcessUsingRabbitMq.RabbitMQ.Connection;
using System.Text;
using System.Text.Json;

namespace OrderProcessUsingRabbitMq.RabbitMQ;

public class RabbitMqProducer : IMessageProducer
{
    private readonly IRabbitMqConnection _rabbitMqConnection;

    public RabbitMqProducer(IRabbitMqConnection rabbitMqConnection)
    {
        this._rabbitMqConnection = rabbitMqConnection;
    }

    public void SendMessage<T>(T message)
    {
        using var channel = _rabbitMqConnection.Connection.CreateModel();

        channel.QueueDeclare("orders", durable: default, exclusive: false, autoDelete: default, default);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "", routingKey: "orders", default, default, body: body);
    }
}
