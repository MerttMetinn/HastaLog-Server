using Microsoft.EntityFrameworkCore;
using PatientLog.Data.Contexts;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public bool AddEntity(T entity)
        {
            _context.Add(entity);

            return true;
        }

        public bool DeleteEntity(T entity)
        {
            _context.Remove(entity);

            return true;
        }

        public List<T> GetAllEntities()
        {
            return Table.ToList();
        }

        public T GetEntityById(int id)
        {
           return Table.FirstOrDefault(x => x.Id == id);    
        }

        public bool SaveChanges()
        {
            _context.SaveChanges();

            return true;
        }

        public bool UpdateEntity(T entity)
        {
            _context.Update(entity);

            return true;
        }
    }
}
