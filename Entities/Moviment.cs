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

        public required int Origin { get; set; }
        public required int Destination { get; set; }
        public required string Responsable { get; set; } = string.Empty;
    }
}
