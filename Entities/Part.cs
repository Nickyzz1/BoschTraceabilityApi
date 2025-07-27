using System.Collections.Generic;

namespace MyApi.Entities
{
    public class Part
    {
        public int Id { get; set; }
        public string Code { get; set; }
        
        // Relação com a estação atual
        public int? CurStationId { get; set; }
        public Station CurStation { get; set; }

        public string Status { get; set; }

        // Histórico de movimentações
        public List<Moviment> Moviments { get; set; }
    }
}
