using System.ComponentModel.DataAnnotations;
namespace MyApi.DTO {
    public class StationCreateDto
    {
        
        public required string Title { get; set; }
        [Required(ErrorMessage = "A ordem é obrigatória.")]
        public required int Sort { get; set; }

    }
}
