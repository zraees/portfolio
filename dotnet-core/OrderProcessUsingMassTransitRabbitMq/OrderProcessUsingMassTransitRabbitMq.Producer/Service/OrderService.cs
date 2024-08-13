using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderProcessUsingMassTransitRabbitMq.Producer.Data;
using OrderProcessUsingMassTransitRabbitMq.Producer.Dtos;
using OrderProcessUsingMassTransitRabbitMq.SharedModels;

namespace OrderProcessUsingMassTransitRabbitMq.Producer.Service;

public class OrderService : IOrderService
{
    private readonly OrderDBContext _orderDBContext;
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderService(OrderDBContext orderDBContext, IPublishEndpoint publishEndpoint)
    {
        this._orderDBContext = orderDBContext;
        this._publishEndpoint = publishEndpoint;
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
            // massTransit
            await _publishEndpoint.Publish<IOrderCreated>(new
            {
                order.Id,
                order.ProductName,
                order.Price,
                order.Quantity,
            });
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
