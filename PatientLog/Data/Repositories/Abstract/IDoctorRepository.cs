using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Abstract
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Doctor GetEntityByEmail(string email);
        bool CheckDoctorExist(string email, string password);
    }
}
