using Oyster.Domain.Models.Enums;

namespace Oyster.Domain.Models;

public class CalculatedRoute : EntityBase
{
    public int[] AreaSequenceIds { get; set; } = default!;
    public RouteState State { get; set; } = RouteState.None;
    public DateTime Timestamp { get; set; }
    public DateTime? ServiceStartTime { get; set; }
    public DateTime? ServiceFinishTime { get; set; }
    public int? AssignedTruckId { get; set; }
    public Truck? AssignedTruck { get; set; }
}