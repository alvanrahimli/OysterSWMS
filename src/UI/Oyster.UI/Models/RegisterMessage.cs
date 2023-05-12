using System.ComponentModel.DataAnnotations;

namespace Oyster.UI.Models;

public record RegisterMessage
{
    [StringLength(255, MinimumLength = 2)] 
    public string FullName { get; set; } = default!;
    [EmailAddress]
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Password2 { get; set; } = default!;
    public bool RememberMe { get; set; }
}
