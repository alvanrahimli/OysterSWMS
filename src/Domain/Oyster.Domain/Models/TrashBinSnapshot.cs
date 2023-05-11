namespace Oyster.Domain.Models;

public class TrashBinSnapshot : EntityBase
{
    public int FilledLevel { get; set; }
    public DateTime Timestamp { get; set; }

    public int TrashBinId { get; set; }
    public TrashBin TrashBin { get; set; } = default!;
}