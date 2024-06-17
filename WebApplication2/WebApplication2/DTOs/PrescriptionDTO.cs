using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DTOs;

public class PrescriptionDTO
{
    
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly? DueDate { get; set; }
    public IEnumerable<PrescriptionMedicamentDTO> Medicaments { get; set; } =null!;
    public DoctorDTO Doctor { get; set; } = null!;

}