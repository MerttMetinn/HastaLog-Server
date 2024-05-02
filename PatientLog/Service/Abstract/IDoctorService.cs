using PatientLog.Domain.Dtos.DoctorDtos;

namespace PatientLog.Service.Abstract
{
    public interface IDoctorService
    {
        void AddDoctor(DoctorAddDto doctorAddDto);
    }
}
