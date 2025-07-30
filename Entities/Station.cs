using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApi.Entities
{
   public class Station
    {
        public int Id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public int Sort { get; set; }
        [JsonIgnore]  
        public List<Part> Parts { get; set; } = new List<Part>();
    }

}
