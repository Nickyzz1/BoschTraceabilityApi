using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApi.Entities
{
    public class Part
    {
        public  int Id { get; set; }
        public  string Code { get; set; }
        
        public  int? CurStationId { get; set; }
        [JsonIgnore]  
        public Station? CurStation { get; set; }

        public required string Status { get; set; } = string.Empty;
        // historic
        public List<Moviment>? Moviments { get; set; } 
    }
}
