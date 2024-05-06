using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Service.Abstract
{
    public interface IDoctorService
    {
        void AddDoctor(DoctorAddDto doctorAddDto);
        void DeleteDoctor(DoctorDeleteDto doctorDeleteDto);
        List<Doctor> GetAllDoctors();
        DoctorGetDto? GetDoctorById(Guid id);
        DoctorGetDto? GetDoctorByEmail(string email);
        bool CheckDoctorExist(string email, string password);
    }
}
