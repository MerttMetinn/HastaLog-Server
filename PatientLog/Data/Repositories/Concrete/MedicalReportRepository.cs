using Dapper;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Concrete
{
    public class MedicalReportRepository : IMedicalReportRepository
    {
        public bool AddEntity(MedicalReport entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(MedicalReport entity)
        {
            throw new NotImplementedException();
        }

        public List<MedicalReport> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public MedicalReport GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
