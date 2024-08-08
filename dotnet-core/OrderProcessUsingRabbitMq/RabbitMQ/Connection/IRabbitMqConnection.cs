using RabbitMQ.Client;

namespace OrderProcessUsingRabbitMq.RabbitMQ.Connection;

public interface IRabbitMqConnection
{
    IConnection Connection { get; }
}
