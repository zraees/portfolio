using Microsoft.EntityFrameworkCore;
using OrderProcessUsingMassTransitRabbitMq.Producer.Data;
using OrderProcessUsingMassTransitRabbitMq.Producer.Dtos;

namespace OrderProcessUsingMassTransitRabbitMq.Producer.Service;

public class OrderService : IOrderService
{
    private readonly OrderDBContext _orderDBContext;

    public OrderService(OrderDBContext orderDBContext)
    {
        this._orderDBContext = orderDBContext;
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
