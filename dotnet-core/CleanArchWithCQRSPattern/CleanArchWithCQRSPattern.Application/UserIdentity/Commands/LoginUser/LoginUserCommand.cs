using CleanArchWithCQRSPattern.Domain.Entities.Identity;
using MediatR;

namespace CleanArchWithCQRSPattern.Application.UserIdentity.Commands.LoginUser;

public record LoginUserCommand (string email, string password) : IRequest<ApplicationUser>;
