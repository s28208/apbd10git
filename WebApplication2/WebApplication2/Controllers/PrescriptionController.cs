using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/prescriptions")]
[ApiController]
public class PrescriptionController: ControllerBase
{
    private readonly IDbService _dbService;
    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> PostNewPrescription(NewPrecriptionDTO newPrescription)
    {
        if (!await _dbService.DoesPatientExist(newPrescription.Patient.IdPatient))
            return NotFound($"Patient with given ID - {newPrescription.Patient.IdPatient} doesn't exist");
        if (!await _dbService.DoesDoctorExist(newPrescription.Doctor.IdDoctor))
            return NotFound($"Doctor with given ID - {newPrescription.Doctor.IdDoctor} doesn't exist");
        var medic = newPrescription.Medicaments;
        foreach (var tmp in medic)
        {
            if (!await _dbService.DoesDoctorExist(tmp.IdMedicament))
                return NotFound($"Medicament with given ID - {tmp.IdMedicament} doesn't exist");
        }

        var prescription = new Prescription()
        {
            Date = newPrescription.Date,
            DueDate = newPrescription.DueDate,
            IdPatient = newPrescription.Patient.IdPatient,
            IdDoctor = newPrescription.Doctor.IdDoctor
        };
        var medicaments = new List<PrescriptionMedicament>();
        foreach (var tmp in newPrescription.Medicaments)
        {
            /*var medicTmp = _dbService.GetMedicamentData(tmp.IdMedicament);
            medicaments.Add(new PrescriptionMedicament()
            {
                IdMedicament = medicTmp.Result.IdMedicament,
                IdPrescription = medicTmp.Result.
            });*/
        }
        return Ok();
    }
}