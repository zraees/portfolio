// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using AutoMapper;
using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Queries.GetUsers;
internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<ApplicationUserVm>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(UserManager<ApplicationUser> userManager, IMapper _mapper)
    {
        _userManager = userManager;
        this._mapper = _mapper;
    }

    public async Task<List<ApplicationUserVm>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await Task.FromResult(_userManager.Users.ToList()).ConfigureAwait(false);

        // mapping entity to VM using AutoMapper
        //var userList = _mapper.Map<List<ApplicationUserVm>>(users);

        var userList = new List<ApplicationUserVm>();
        foreach (var user in users)
        {
            userList.Add(new ApplicationUserVm() { id = user.Id, FriendlyName = user.FriendlyName, Email = user.Email ?? "" });
        }

        return userList;
    }
}
