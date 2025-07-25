namespace BoschTraceabilityAPI.Domain.Entities;
public class Station
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int Sort { get; set; }  // 1, 2, 3...
}
