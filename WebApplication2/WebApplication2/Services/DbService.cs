using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
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
        if (!await (DoesPatientExist(idPatient)))
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



    public async Task<bool> DoesPatientExist(int idPatient)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == idPatient);
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