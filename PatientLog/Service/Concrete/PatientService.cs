using PatientLog.Data.Repositories.Abstract;
using PatientLog.Data.Repositories.Concrete;
using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Domain.Dtos.PatientDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;

namespace PatientLog.Service.Concrete
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public void AddPatient(PatientAddDto patientAddDto)
        {
            Patient patient = new Patient()
            {
                Name = patientAddDto.Name,
                Surname = patientAddDto.Surname,
                Email = patientAddDto.Email,
                Password = patientAddDto.Password,
                BirthDate = patientAddDto.BirthDate,
                Gender = patientAddDto.Gender,
                PhoneNumber = patientAddDto.PhoneNumber,
                Address = patientAddDto.Address,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            _patientRepository.AddEntity(patient);
        }
        public void DeletePatient(PatientDeleteDto patientDeleteDto)
        {
            Patient? patient = _patientRepository.GetEntityById(patientDeleteDto.Id);
            if (patient != null)
            {
                _patientRepository.DeleteEntity(patient);
            }
        }
        public List<Patient> GetAllPatients()
        {
            var patients = _patientRepository.GetAllEntities();

            return patients;
        }
        public PatientGetDto? GetPatientById(Guid id)
        {
            var patient = _patientRepository.GetEntityById(id);
            if (patient == null)
            {
                return null;
            }
            PatientGetDto patientGetDto = new PatientGetDto()
            {
                Id = id,
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Password = patient.Password,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
            };
            return patientGetDto;
        }
        public bool CheckPatientExist(string email, string password)
        {
            return _patientRepository.CheckPatientExist(email, password);
        }
        public PatientGetDto? GetPatientByEmail(string email)
        {
            var patient = _patientRepository.GetEntityByEmail(email);
            if (patient == null)
            {
                return null;
            }
            PatientGetDto patientGetDto = new PatientGetDto()
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Password = patient.Password,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
            };
            return patientGetDto;
        }
    }
}
