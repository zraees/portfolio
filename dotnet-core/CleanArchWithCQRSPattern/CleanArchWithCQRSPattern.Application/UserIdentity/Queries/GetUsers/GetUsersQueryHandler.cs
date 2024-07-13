// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Queries.GetUsers;
internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<ApplicationUser>>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public GetUsersQueryHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<ApplicationUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_userManager.Users.ToList()).ConfigureAwait(false);
    }
}
