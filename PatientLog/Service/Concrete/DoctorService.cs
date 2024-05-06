using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Domain.Entities;
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
        public void AddDoctor(DoctorAddDto doctorAddDto)
        {
            Doctor doctor = new Doctor()
            {
                Name = doctorAddDto.Name,
                Surname = doctorAddDto.Surname,
                Email = doctorAddDto.Email,
                Password = doctorAddDto.Password,
                BirthDate = doctorAddDto.BirthDate,
                Gender = doctorAddDto.Gender,
                PhoneNumber = doctorAddDto.PhoneNumber,
                Address = doctorAddDto.Address,
                SpecializationArea = doctorAddDto.SpecializationArea,
                HospitalName = doctorAddDto.HospitalName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            _doctorRepository.AddEntity(doctor);
        }
        public void DeleteDoctor(DoctorDeleteDto doctorDeleteDto)
        {
            Doctor? doctor = _doctorRepository.GetEntityById(doctorDeleteDto.Id);
            if (doctor != null)
            {
                _doctorRepository.DeleteEntity(doctor);
            }
        }
        public List<Doctor> GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAllEntities();

            return doctors;
        }
        public DoctorGetDto? GetDoctorById(Guid id)
        {
            var doctor = _doctorRepository.GetEntityById(id);
            if (doctor == null)
            {
                return null;
            }
            DoctorGetDto doctorGetDto = new DoctorGetDto()
            {
                Id = id,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Password = doctor.Password,
                BirthDate = doctor.BirthDate,
                Gender = doctor.Gender,
                PhoneNumber = doctor.PhoneNumber,
                Address = doctor.Address,
                SpecializationArea = doctor.SpecializationArea,
                HospitalName = doctor.HospitalName,
            };
            return doctorGetDto;
        }
        public bool CheckDoctorExist(string email, string password)
        {
            return _doctorRepository.CheckDoctorExist(email, password);
        }
        public DoctorGetDto? GetDoctorByEmail(string email)
        {
            var doctor = _doctorRepository.GetEntityByEmail(email);
            if (doctor == null)
            {
                return null;
            }
            DoctorGetDto doctorGetDto = new DoctorGetDto()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Password = doctor.Password,
                BirthDate = doctor.BirthDate,
                Gender = doctor.Gender,
                PhoneNumber = doctor.PhoneNumber,
                Address = doctor.Address,
                SpecializationArea = doctor.SpecializationArea,
                HospitalName = doctor.HospitalName,
            };
            return doctorGetDto;
        }
    }
}
