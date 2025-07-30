using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace MyApi.DTO {
   public class PartUpdateDto
    {
        [Required(ErrorMessage = "O código é obrigatório.")]
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

}
