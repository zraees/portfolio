// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Commands.GenerateAuthToken;

public class GenerateAuthTokenCommandHandler : IRequestHandler<GenerateAuthTokenCommand, string>
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _Key;

    public GenerateAuthTokenCommandHandler(IConfiguration configuration)
    {
        _configuration = configuration;
        _Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
    }

    public Task<string> Handle(GenerateAuthTokenCommand request, CancellationToken cancellationToken)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, request.applicationUser.Email),
            new Claim (ClaimTypes.GivenName, request.applicationUser.FriendlyName),
        };

        var cred = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha512Signature);
        var TokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Audience = _configuration["Token:Audience"],//request.applicationUser.FriendlyName,
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = cred,
            Issuer = _configuration["Token:Issuer"],
        };

        var tokenhandler = new JwtSecurityTokenHandler();
        var token = tokenhandler.CreateToken(TokenDesc);
        return Task.FromResult(tokenhandler.WriteToken(token));
    }
}
