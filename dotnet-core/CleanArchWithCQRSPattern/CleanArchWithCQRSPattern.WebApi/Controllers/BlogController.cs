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
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _sender.Send(new GetBlogsQuery()).ConfigureAwait(false);
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var blog = await _sender.Send(new GetBlogByIdQuery(id)).ConfigureAwait(false);
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blog);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogCommand createBlogCommand)
        {
            var createdBlog= await _sender.Send(createBlogCommand).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateBlogCommand updateBlogCommand)
        {
            if (id != updateBlogCommand.id)
            {
                return BadRequest();
            }

            await _sender.Send(updateBlogCommand).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _sender.Send(new DeleteBlogCommand(id)).ConfigureAwait(false);
            return NoContent();
        }
    }
}
