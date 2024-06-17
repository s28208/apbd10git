using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class MedicamentDTO
{
    [Required]
    public int IdMedicament { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } 
    [MaxLength(100)]
    public string Description { get; set; } 
    
}