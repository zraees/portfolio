using Microsoft.AspNetCore.Identity;

namespace CleanArchWithCQRSPattern.Domain.Entities.Identity;
public class ApplicationUser : IdentityUser
{
    public string FriendlyName { get; set; } = string.Empty;
}
