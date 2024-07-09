// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchWithCQRSPattern.Application.UserIdentity.Commands.LoginUser;
using CleanArchWithCQRSPattern.Application.UserIdentity.Commands.RegisterUser;
using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using CleanArchWithCQRSPattern.WebApi.Dtos;
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

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = registerUserDTO.UserName,
            Email = registerUserDTO.Email,
            FriendlyName = registerUserDTO.FriendlyName,
        };

        var registerUserCommand = new RegisterUserCommand(applicationUser, registerUserDTO.Password);
        var appUser = await _sender.Send(registerUserCommand).ConfigureAwait(false);
        return Ok(appUser);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
    {
        var AppUser = await _sender.Send(loginUserCommand).ConfigureAwait(false);

        return Ok(AppUser);
    }
}
