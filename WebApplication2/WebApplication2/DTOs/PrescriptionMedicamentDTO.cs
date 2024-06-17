using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class PrescriptionMedicamentDTO
{
    public int IdMedicament { get; set; }
    
    public string Name { get; set; } 
    public int? Dose { get; set; }
   
    public string Description { get; set; } 
}