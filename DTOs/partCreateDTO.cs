using System.ComponentModel.DataAnnotations;

public class PartCreateDto
{
    [Required(ErrorMessage = "O código é obrigatório.")]
    public string Code { get; set; }

    [Required(ErrorMessage = "O status é obrigatório.")]
    public string Status { get; set; }

    public int CurStationId { get; set; }
}
