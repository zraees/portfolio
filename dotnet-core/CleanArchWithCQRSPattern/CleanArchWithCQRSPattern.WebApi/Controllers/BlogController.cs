using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSPattern.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : BaseApiController
    {
        private readonly ISender _sender;

        public BlogController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs(){
            var blogs =await _sender.Send(new GetBlogsQuery()).ConfigureAwait(false);
            return Ok(blogs);
        }
    }
}