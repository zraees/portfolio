// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchWithCQRSPattern.Application.UserIdentity.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSPattern.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : BaseApiController
{
    private readonly ISender _sender;

    public AccountController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
    {
        var appUser = await _sender.Send(registerUserCommand).ConfigureAwait(false);
        return Ok(appUser);
    }
}
