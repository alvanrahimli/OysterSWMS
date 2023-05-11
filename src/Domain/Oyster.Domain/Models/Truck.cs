using Oyster.Domain.Models.Enums;

namespace Oyster.Domain.Models;

public class Truck : EntityBase
{
    public string SerialNumber { get; set; } = default!;
    public decimal[] Location { get; set; } = default!;
    public TruckState State { get; set; } = TruckState.None;
}