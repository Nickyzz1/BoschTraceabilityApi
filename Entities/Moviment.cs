using System;

namespace MyApi.Entities
{
    public class Moviment
    {
        public int Id { get; set; }

        // FK para Part
        public int PartId { get; set; }
        public Part Part { get; set; }

        public DateTime DateTime { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Responsable { get; set; }
    }
}
