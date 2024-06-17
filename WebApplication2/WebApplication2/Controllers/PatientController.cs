using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/patients")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IDbService _dbService;
    public PatientController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{idPatient:int}")]
    public async Task<IActionResult> GetOrdersData(int idPatient)
    {
        var patient = await _dbService.GetPatientData(idPatient);
        
        return Ok(patient.Select(e => new PatientDTO()
        {
            IdPatient = e.IdPatient,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Birthdate = e.Birthdate,
            Prescriptions = e.Prescriptions.Select(p => new PrescriptionDTO()
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Doctor = new DoctorDTO()
                {
                    IdDoctor = p.IdDoctor,
                    FirstName = p.Doctor.FirstName
                },
                Medicaments = p.PrescriptionMedicaments.Select(m => new PrescriptionMedicamentDTO()
                {
                    IdMedicament = m.IdMedicament,
                    Name = m.Medicament.Name,
                    Dose = m.Dose,
                    Description = m.Medicament.Description
                })
                
            }).ToList()
        }));
    }
}