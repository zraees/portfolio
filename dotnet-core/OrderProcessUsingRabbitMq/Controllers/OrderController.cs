using Microsoft.AspNetCore.Mvc;
using OrderProcessUsingRabbitMq.Data;
using OrderProcessUsingRabbitMq.Dtos;
using OrderProcessUsingRabbitMq.Service;

namespace OrderProcessUsingRabbitMq.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            this._orderService = orderService;
        }

        [HttpGet(Name = "GetOrders")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderService.GetAll().ConfigureAwait(false));
        }

        [HttpPost(Name = "SaveOrder")]
        public async Task<IActionResult> Post(OrderDto orderDto)
        {
            return Ok(await _orderService.Save(orderDto).ConfigureAwait(false));
        }
    }
}
