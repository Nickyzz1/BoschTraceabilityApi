namespace BoschTraceabilityAPI.Domain.Entities;
using BoschTraceabilityAPI.Domain.Enums;

public class Part
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = string.Empty;
    public StatusPart Status { get; set; } = StatusPart.Recebida;
    public List<Moviment> History { get; set; } = new();
}
