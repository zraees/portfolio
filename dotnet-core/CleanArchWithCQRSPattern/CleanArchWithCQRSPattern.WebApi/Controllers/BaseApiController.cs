using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSPattern.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
//         private readonly ISender _mediator;
// protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>(); 
//         // public BaseApiController(ISender sender)
//         // {
//         //     _sender = sender;
//         // }
    }
}