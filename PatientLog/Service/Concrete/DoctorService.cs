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
                CreatedDate = DateTime.Now,
                Name = doctorAddDto.Name,
                Surname = doctorAddDto.Surname,
                Email = doctorAddDto.Email,
                Password = doctorAddDto.Password,
                BirthDate = doctorAddDto.BirthDate,
                Gender = doctorAddDto.Gender,
                PhoneNumber = doctorAddDto.PhoneNumber,
                Adress = doctorAddDto.Adress,
                SpecializationArea = doctorAddDto.SpecializationArea,
                HospitalName = doctorAddDto.HospitalName,
            };

            _doctorRepository.AddEntity(doctor);
        }
    }
}
