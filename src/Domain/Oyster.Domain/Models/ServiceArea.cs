namespace Oyster.Domain.Models;

public class ServiceArea : EntityBase
{
    public string AreaName { get; set; } = default!;
    // Can not be mapped
    // public decimal[][]? AreaPolygon { get; set; }

    public ICollection<BinArea> BinAreas { get; set; } = new List<BinArea>();
}
