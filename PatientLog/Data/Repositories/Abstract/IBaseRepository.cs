using Microsoft.EntityFrameworkCore;

namespace PatientLog.Data.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        T GetEntityById(int id);
        List<T> GetAllEntities();
        bool AddEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        bool SaveChanges();

    }
}
