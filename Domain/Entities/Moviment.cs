namespace BoschTraceabilityAPI.Domain.Entities;
using BoschTraceabilityAPI.Domain.Entities;
public class Moviment
{
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public string Origin { get; set; } = "";
    public string Destination { get; set; } = "";
    public string Responsable { get; set; } = "";
}
