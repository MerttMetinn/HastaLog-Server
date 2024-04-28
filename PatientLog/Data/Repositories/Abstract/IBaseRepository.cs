using Microsoft.EntityFrameworkCore;

namespace PatientLog.Data.Repositories.Abstract
{
    public interface IBaseRepository<T>
    {
        T GetEntityById(int id);
        List<T> GetAllEntities();
        bool AddEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        bool SaveChanges();

    }
}
