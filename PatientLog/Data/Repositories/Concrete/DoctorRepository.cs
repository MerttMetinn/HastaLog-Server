using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Concrete
{
    public class DoctorRepository : IDoctorRepository
    {
        public bool AddEntity(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Doctor GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
