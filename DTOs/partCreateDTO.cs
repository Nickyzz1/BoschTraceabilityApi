using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace MyApi.DTO {
    public class PartCreateDto
    {
        [Required(ErrorMessage = "O código é obrigatório.")]
        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
         [JsonPropertyName("status")]
        public required string Status { get; set; }
        [JsonPropertyName("curStationId")]
        public required int CurStationId { get; set; }
    }
}
