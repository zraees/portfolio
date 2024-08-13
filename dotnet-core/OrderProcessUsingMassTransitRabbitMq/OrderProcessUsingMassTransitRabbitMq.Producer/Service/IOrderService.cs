
using OrderProcessUsingMassTransitRabbitMq.Producer.Data;
using OrderProcessUsingMassTransitRabbitMq.Producer.Dtos;

namespace OrderProcessUsingMassTransitRabbitMq.Producer.Service;

public interface IOrderService
{
    Task<Order> Save(OrderDto orderDto);

    Task<List<Order>> GetAll();
}
