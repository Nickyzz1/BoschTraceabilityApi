using System;

namespace MyApi.Entities
{
    public class Moviment
    {
        public int Id { get; set; }

        // FK para Part
        public  int PartId { get; set; }
        public  Part Part { get; set; }

        public  DateTime DateTime { get; set; }

        public required string Origin { get; set; } = string.Empty;
        public required string Destination { get; set; } = string.Empty;
        public required string Responsable { get; set; } = string.Empty;
    }
}
