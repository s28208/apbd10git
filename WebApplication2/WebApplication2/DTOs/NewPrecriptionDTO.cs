using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class NewPrecriptionDTO
{
    [Required]
    public NewPatientDTO Patient { get; set; }
    [Required]
    public ICollection<NewPrescriptionMedicamentDTO> Medicaments { get; set; } = new List<NewPrescriptionMedicamentDTO>();
    [Required]
    public NewDoctorDTO Doctor { get; set; }
    [Required]
    public DateOnly Date { get; set; } 
    [Required]
    public DateOnly DueDate { get; set; } 
}