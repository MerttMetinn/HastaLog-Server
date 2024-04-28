using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Abstract
{
    public interface IAdminRepository: IBaseRepository<Admin>
    {
        void ChangeUserPassword(int userId, string password);   
    }
}
