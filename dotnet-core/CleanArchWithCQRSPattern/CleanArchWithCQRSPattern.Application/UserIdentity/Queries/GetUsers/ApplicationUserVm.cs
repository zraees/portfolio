// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchWithCQRSPattern.Domain.Entities.Identity;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Queries.GetUsers;
internal class ApplicationUserVm : IMapFrom<ApplicationUser>
{
    public string id { get; set; }

    public string FriendlyName { get; set; } = string.Empty;

    public string Email { get; set; }
}
