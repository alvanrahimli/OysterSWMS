namespace Oyster.Domain.Models;

public class Media : EntityBase
{
    public string FileKey { get; set; } = default!;
    public bool Processed { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime Expiration { get; set; }

    public int TrashBinId { get; set; }
    public TrashBin TrashBin { get; set; } = default!;
}