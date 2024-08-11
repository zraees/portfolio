using Publisher.Data;
using Publisher.Dtos;

namespace Publisher.Service;

public interface IOrderService
{
    Task<Order> Save(OrderDto orderDto);

    Task<List<Order>> GetAll();
}
