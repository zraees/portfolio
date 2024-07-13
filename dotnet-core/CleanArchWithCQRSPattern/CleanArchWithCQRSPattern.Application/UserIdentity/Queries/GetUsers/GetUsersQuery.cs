// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Security.Claims;
using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Queries.GetUsers;

public record GetUsersQuery() : IRequest<List<ApplicationUser>>;
