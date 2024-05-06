using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Abstract
{
    public interface IAdminRepository: IBaseRepository<Admin>
    {
        Admin GetEntityByEmail(string email);
        bool CheckAdminExist(string email, string password);
    }
}
