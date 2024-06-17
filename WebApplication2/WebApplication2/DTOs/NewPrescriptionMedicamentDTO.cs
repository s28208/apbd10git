using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class NewPrescriptionMedicamentDTO
{
    [Required]
    public int IdMedicament { get; set; }

    public int? Dose { get; set; } = null;
    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;
    
}