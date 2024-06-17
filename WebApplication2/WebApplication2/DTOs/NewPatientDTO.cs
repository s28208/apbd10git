using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class NewPatientDTO
{
    [Required]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    [Required]
    public DateOnly Birtdate { get; set; }
}