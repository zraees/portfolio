// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Commands.GenerateAuthToken;

public record GenerateAuthTokenCommand(ApplicationUser applicationUser) : IRequest<string>;
