using PatientLog.Data.Repositories.Abstract;
using PatientLog.Service.Abstract;

namespace PatientLog.Service.Concrete
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository repository)
        {
            _doctorRepository = repository;
        }

    }
}
