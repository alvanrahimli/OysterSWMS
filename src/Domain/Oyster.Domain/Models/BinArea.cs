namespace Oyster.Domain.Models;

public class BinArea : EntityBase
{
    public int WeightAddition { get; set; }
    public string AddressTitle { get; set; } = default!;
    public decimal[] Location { get; set; } = default!;
    public int ServiceAreaId { get; set; }
    public ServiceArea ServiceArea { get; set; } = default!;

    public ICollection<TrashBin> TrashBins { get; set; } = new List<TrashBin>();
}
