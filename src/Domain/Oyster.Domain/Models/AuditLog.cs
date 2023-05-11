namespace Oyster.Domain.Models;

public class AuditLog : EntityBase
{
    public string Message { get; set; } = default!;
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }
    public AppUser User { get; set; } = default!;
}