using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Commands.RegisterUser;
public record RegisterUserCommand (ApplicationUser appUser, string password): IRequest<ApplicationUser>;
