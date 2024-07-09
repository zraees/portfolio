namespace CleanArchWithCQRSPattern.WebApi.Dtos;

public class RegisterUserDTO
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string FriendlyName { get; set; }
}
