using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IDbService
{
    public Task<ICollection<Patient>> GetPatientData(int idPatient);
    public  Task<bool> DoesPatientExist(int idPatient);
    public  Task<bool> DoesDoctorExist(int idDoctor);
    public Task<Medicament> GetMedicamentData(int idMedicament);


}