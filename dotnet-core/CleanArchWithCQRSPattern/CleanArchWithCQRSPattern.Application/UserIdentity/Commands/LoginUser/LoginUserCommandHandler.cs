using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<ApplicationUser> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var appUser = await _userManager.FindByEmailAsync(request.email).ConfigureAwait(false);
        if (appUser == null)
        {
            throw new KeyNotFoundException("Email address does not exist.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, request.password, false).ConfigureAwait(false);

        if (result.Succeeded == false)
        {
            throw new KeyNotFoundException("Password not matched");
        }

        return appUser;
    }
}
