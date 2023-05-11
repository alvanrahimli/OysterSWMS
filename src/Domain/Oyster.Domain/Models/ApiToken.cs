namespace Oyster.Domain.Models;

public class ApiToken : EntityBase
{
    public string Token { get; set; } = default!;
    public int UsageCount { get; set; }
    public DateTime Expiration { get; set; }
    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }
    public AppUser User { get; set; } = default!;
}