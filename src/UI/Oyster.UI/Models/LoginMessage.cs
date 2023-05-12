namespace Oyster.UI.Models;

public record LoginMessage
{
    public LoginMessage(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public LoginMessage()
    { }
    
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
