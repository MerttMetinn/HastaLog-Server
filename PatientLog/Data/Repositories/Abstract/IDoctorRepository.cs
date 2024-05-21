using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Abstract
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Doctor GetEntityByEmail(string email);
        Doctor GetEntityByFullName(string name, string surname);
        bool CheckDoctorExist(string email, string password);
        List<Doctor> GetAllDoctorsBySpecializationArea(string SpecializationArea, string HospitalName);
    }
}
