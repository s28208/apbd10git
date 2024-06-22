using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IDbService
{
    public Task<ICollection<Patient>> GetPatientData(int idPatient);
    public  Task<bool> DoesPatientExist(Patient patient);
    public  Task<bool> DoesDoctorExist(int idDoctor);
    public Task<Medicament> GetMedicamentData(int idMedicament);
    public Task<bool> DoesMedicamentExist(int idMedicament);
    public Task AddNewPatient(Patient patient);

    public Task<bool> DoesPatientExistByID(int idPatient);
    public Task<Prescription> AddNewPrescription(Prescription prescription);
    public Task AddNewPrescriptionMedicament(List<PrescriptionMedicament> prescriptionMedicaments);


}