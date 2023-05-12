using Oyster.Domain.Models.Enums;

namespace Oyster.Domain.Models;

public class TrashBin : EntityBase
{
    public int FilledLevel { get; set; }
    public DateTime LastPingTimestamp { get; set; }
    public TrashBinType Type { get; set; } = TrashBinType.None;
    public string SensorSerialNumber { get; set; } = default!;
    public int BinAreaId { get; set; }
    public BinArea BinArea { get; set; } = default!;

    public bool Deleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<TrashBinSnapshot> Snapshots { get; set; } = new List<TrashBinSnapshot>();
    public ICollection<Media> Medias { get; set; } = new List<Media>();
}
