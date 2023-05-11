namespace Oyster.Domain.Models;

public class EntityBase
{
    public int Id { get; set; }

    public override string ToString() => $"{GetType().Name}[Id={Id}]";
}