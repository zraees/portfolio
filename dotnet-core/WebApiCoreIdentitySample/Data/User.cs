using Microsoft.AspNetCore.Identity;

namespace WebApiCoreIdentitySample.Data
{
    public class User : IdentityUser
    {
        public string FriendlyName { get; set; } = string.Empty;
    }
}
