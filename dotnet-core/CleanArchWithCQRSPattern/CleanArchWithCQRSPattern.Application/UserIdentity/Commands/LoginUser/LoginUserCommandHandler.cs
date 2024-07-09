using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var appUser = await _userManager.FindByEmailAsync(request.email).ConfigureAwait(false);
        if (appUser == null)
        {
            throw new KeyNotFoundException("Email address does not exist.");
        }

        var isLoginSuccess = await _userManager.CheckPasswordAsync(appUser, request.password).ConfigureAwait(false);

        if (isLoginSuccess == false)
        {
            throw new KeyNotFoundException("Password not matched");
        }

        return appUser;
    }
}
