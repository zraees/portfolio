using RabbitMQ.Client;

namespace Publisher.RabbitMQ.Connection;

public interface IRabbitMqConnection
{
    IConnection Connection { get; }
}
