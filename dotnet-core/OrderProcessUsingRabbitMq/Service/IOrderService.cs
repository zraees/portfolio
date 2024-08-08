using OrderProcessUsingRabbitMq.Data;
using OrderProcessUsingRabbitMq.Dtos;

namespace OrderProcessUsingRabbitMq.Service;

public interface IOrderService
{
    Task<Order> Save(OrderDto orderDto);

    Task<List<Order>> GetAll();
}
