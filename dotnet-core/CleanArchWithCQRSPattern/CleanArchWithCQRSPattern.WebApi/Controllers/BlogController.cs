// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSPattern.WebApi.Controllers
{
    [Authorize]
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
            var result = await _sender.Send(new GetBlogsQuery()).ConfigureAwait(false);

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _sender.Send(new GetBlogByIdQuery(id)).ConfigureAwait(false);

            if (result.IsFailed)
            {
                return ResultFailerHandler(result);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogCommand createBlogCommand)
        {
            var result = await _sender.Send(createBlogCommand).ConfigureAwait(false);

            if (result.IsFailed)
            {
                return ResultFailerHandler(result);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
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
