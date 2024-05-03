using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Domain.Dtos.PatientDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Service.Abstract
{
    public interface IPatientService
    {
        void AddPatient(PatientAddDto patientAddDto);
        void DeletePatient(PatientDeleteDto patientDeleteDto);
        List<Patient> GetAllPatients();
        PatientGetDto? GetPatientById(Guid id);
    }
}
