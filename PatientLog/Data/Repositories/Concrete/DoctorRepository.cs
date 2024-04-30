using PatientLog.Data.Contexts;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Concrete
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
