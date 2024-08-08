using Microsoft.EntityFrameworkCore;
using OrderProcessUsingRabbitMq.Data;
using OrderProcessUsingRabbitMq.Dtos;

namespace OrderProcessUsingRabbitMq.Service;

public class OrderService: IOrderService
{
    private readonly OrderDBContext orderDBContext;

    public OrderService(OrderDBContext orderDBContext)
    {
        this.orderDBContext = orderDBContext;
    }

    public async Task<List<Order>> GetAll()
    {
        return await orderDBContext.Orders.ToListAsync();
    }

    public async Task<Order> Save(OrderDto orderDto)
    {
        Order order = new Order
        {
            ProductName = orderDto.ProductName,
            Quantity = orderDto.Quantity,
            Price = orderDto.Price
        };

        orderDBContext.Orders.Add(order);
        order.Id  = await orderDBContext.SaveChangesAsync();

        return order;
    }
}
