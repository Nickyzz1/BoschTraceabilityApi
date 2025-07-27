using System.Collections.Generic;

namespace MyApi.Entities
{
    public class Station
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Sort { get; set; }

        // Partes que estão atualmente nesta estação
        public List<Part> Parts { get; set; }
    }
}
