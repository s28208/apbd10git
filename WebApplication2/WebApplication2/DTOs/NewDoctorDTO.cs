using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class NewDoctorDTO
{
    [Required]
    public int IdDoctor { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = null!;
}