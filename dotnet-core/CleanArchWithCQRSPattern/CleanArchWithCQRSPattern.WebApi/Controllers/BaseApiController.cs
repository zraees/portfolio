// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchWithCQRSPattern.Application.Common.Exceptions.Errors;
using FluentResults;
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

        internal IActionResult ResultFailerHandler(Result<BlogsVm> result)
        {
            if (result.HasError<RecordNotFoundError>())
            {
                return NotFound(result.Errors);
            }
            else
            //if (result.HasError<ValidationError>())
            {
                return BadRequest(result.Errors);
            }
        }

    }
}
