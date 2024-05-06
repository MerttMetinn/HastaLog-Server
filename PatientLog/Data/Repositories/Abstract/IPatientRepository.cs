using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Abstract
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Patient GetEntityByEmail(string email);
        bool CheckPatientExist(string email, string password);
    }
}
