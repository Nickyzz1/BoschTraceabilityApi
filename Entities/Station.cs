using System.Collections.Generic;

namespace MyApi.Entities
{
   public class Station
    {
        public int Id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public int Sort { get; set; }

        public List<Part> Parts { get; set; } = new List<Part>();
    }

}
