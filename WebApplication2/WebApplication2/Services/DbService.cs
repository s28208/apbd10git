using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Patient>> GetPatientData(int idPatient)
    {
        if (!await (DoesPatientExistByID(idPatient)))
        {
            throw new AsnContentException("Not Found Patient");
            
        }
        return await _context.Patients

            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Medicament)
            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.Doctor)
            .Where(e => e.IdPatient == idPatient)
            .ToListAsync();
        
    }

    public async Task<Medicament?> GetMedicamentData(int idMedicament)
    {
        return await _context.Medicaments.FirstOrDefaultAsync(e => e.IdMedicament == idMedicament);
    }

    public async Task AddNewPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<Prescription> AddNewPrescription(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
        return prescription;
    }

    public async Task AddNewPrescriptionMedicament(List<PrescriptionMedicament> prescriptionMedicaments)
    {
        await _context.AddRangeAsync(prescriptionMedicaments);
        await _context.SaveChangesAsync();
    }


    public async Task<bool> DoesPatientExistByID(int idPatient)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == idPatient);
    }


    public async Task<bool> DoesPatientExist(Patient patient)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == patient.IdPatient && e.FirstName == patient.FirstName && e.LastName == patient.LastName && e.Birthdate == patient.Birthdate);
    }
    

    public async Task<bool> DoesDoctorExist(int idDoctor)
    {
        return await _context.Doctors.AnyAsync(e => e.IdDoctor == idDoctor);
    }
    public async Task<bool> DoesMedicamentExist(int idMedicament)
    {
        return await _context.Medicaments.AnyAsync(e => e.IdMedicament == idMedicament);
    }
}