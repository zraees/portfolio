using Microsoft.EntityFrameworkCore;
using OrderProcessUsingRabbitMq.Data;
using OrderProcessUsingRabbitMq.Dtos;
using OrderProcessUsingRabbitMq.RabbitMQ;

namespace OrderProcessUsingRabbitMq.Service;

public class OrderService : IOrderService
{
    private readonly OrderDBContext _orderDBContext;
    private readonly IMessageProducer _messageProducer;

    public OrderService(OrderDBContext orderDBContext, IMessageProducer messageProducer)
    {
        this._orderDBContext = orderDBContext;
        this._messageProducer = messageProducer;
    }

    public async Task<List<Order>> GetAll()
    {
        return await _orderDBContext.Orders.ToListAsync();
    }

    public async Task<Order> Save(OrderDto orderDto)
    {
        Order order = await SaveOrder(orderDto).ConfigureAwait(false);

        if (order is not null)
        {
            _messageProducer.SendMessage(order);
        }

        return order!;
    }

    public async Task<Order> SaveOrder(OrderDto orderDto)
    {
        var order = new Order
        {
            ProductName = orderDto.ProductName,
            Quantity = orderDto.Quantity,
            Price = orderDto.Price
        };

        _orderDBContext.Orders.Add(order);
        await _orderDBContext.SaveChangesAsync();

        return order;
    }
}
