using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DTOs;

public class PatientDTO
{
   
    public int IdPatient { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public DateOnly Birthdate { get; set; }
    public ICollection<PrescriptionDTO> Prescriptions { get; set; } = null!;
}