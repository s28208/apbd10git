namespace WebApplication2.Models;

using System.ComponentModel.DataAnnotations;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();

    
}