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
        
        if (!await _dbService.DoesDoctorExist(newPrescription.Doctor.IdDoctor))
            return NotFound($"Doctor with given ID - {newPrescription.Doctor.IdDoctor} doesn't exist");
        var medic = newPrescription.Medicaments;
        int count = 0;
        foreach (var tmp in medic)
        {
            if (!await _dbService.DoesMedicamentExist(tmp.IdMedicament))
                return NotFound($"Medicament with given ID - {tmp.IdMedicament} doesn't exist");
            count++;
        }

        if (count > 10)
        {
            throw new ArgumentException("Too many medications in the prescription");
        }

        if (newPrescription.DueDate < newPrescription.Date)
        {
            throw new ArgumentException("DueData<Data");
        }
        var newPatient = new Patient()
        {
            IdPatient = newPrescription.Patient.IdPatient,
            FirstName = newPrescription.Patient.FirstName,
            LastName = newPrescription.Patient.LastName,
            Birthdate = newPrescription.Patient.Birtdate
        };
        if (!await _dbService.DoesPatientExistByID(newPrescription.Patient.IdPatient))
        {
            await _dbService.AddNewPatient(newPatient);
        }
        else
        {
            if(!await _dbService.DoesPatientExist(newPatient))
            {
                return NotFound($"This given ID of Patient does exist");
            }
            
        }
        var prescription = new Prescription()
        {
            Date = newPrescription.Date,
            DueDate = newPrescription.DueDate,
            IdPatient = newPrescription.Patient.IdPatient,
            IdDoctor = newPrescription.Doctor.IdDoctor,
                                 
        };
        var newidPrescription =await  _dbService.AddNewPrescription(prescription);
        
        // add prescriptionwithhmedicament
        var medicaments = new List<PrescriptionMedicament>();
        foreach (var tmp in newPrescription.Medicaments)
        {
            var medicTmp = await _dbService.GetMedicamentData(tmp.IdMedicament);
            medicaments.Add(new PrescriptionMedicament()
            {
                IdMedicament = medicTmp.IdMedicament,
                IdPrescription = newidPrescription.IdPrescription,
                Details = medicTmp.Description,
                Dose = tmp.Dose
            });
        }

        await _dbService.AddNewPrescriptionMedicament(medicaments);
         
        return Created();
    }
}