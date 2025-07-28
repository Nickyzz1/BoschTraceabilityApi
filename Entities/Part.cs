using System.Collections.Generic;

namespace MyApi.Entities
{
    public class Part
    {
        public  int Id { get; set; }
        public  string Code { get; set; }
        
        // Relação com a estação atual
        public  int? CurStationId { get; set; }
        public  Station CurStation { get; set; }

        public required string Status { get; set; } = string.Empty;

        // Histórico de movimentações
        public List<Moviment>? Moviments { get; set; } 
    }
}
