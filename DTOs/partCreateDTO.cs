using System.ComponentModel.DataAnnotations;
namespace MyApi.DTO {
    public class PartCreateDto
    {
        [Required(ErrorMessage = "O código é obrigatório.")]
        public required string Code { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public required string Status { get; set; }

        public required int CurStationId { get; set; }
    }
}
