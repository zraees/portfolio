// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Commands.RegisterUser;
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        //validate email already exists.
        if ((_userManager.FindByEmailAsync(request.appUser?.Email ?? "").Result?.Email ?? "").Length > 0)
        {
            throw new InvalidDataException("Email already exists.");
        }

        await _userManager.CreateAsync(request.appUser, request.password).ConfigureAwait(false);
        return request.appUser;
    }
}
