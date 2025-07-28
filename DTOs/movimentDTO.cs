using System.ComponentModel.DataAnnotations;
namespace MyApi.DTO {
    public class MovimentCreateDto
    {
        public int PartId { get; set; }
        public int DestinationStationId { get; set; }
        public string Responsable { get; set; } = string.Empty;
    }
}
