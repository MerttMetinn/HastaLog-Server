namespace PatientLog.Data.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        T GetEntityById(Guid id);
        List<T> GetAllEntities();
        bool AddEntity(T entity);
        bool DeleteEntity(T entity);
    }
}
