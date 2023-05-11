using Oyster.Domain.Models.Enums;

namespace Oyster.Domain.Models;

public sealed class AppUser : EntityBase
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public List<Role> Roles { get; set; } = new List<Role>();
    
    public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
}
