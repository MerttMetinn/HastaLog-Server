using PatientLog.Data.Repositories.Abstract;
using PatientLog.Data.Repositories.Concrete;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;
using System.Linq;

namespace PatientLog.Service.Concrete
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public void AddAdmin(AdminAddDto adminAddDto)
        {
            Admin admin = new Admin()
            {
                CreatedDate = DateTime.Now,
                Name = adminAddDto.Name,
                Surname = adminAddDto.Surname,
                Password = adminAddDto.Password,
                Email = adminAddDto.Email,
            };

            //  _repository.AddEntity(admin);

            _adminRepository.Table.Add(admin);

            _adminRepository.SaveChanges();
        }

        public AdminGetDto? GetAdminById(int id)
        {
            var admin = _adminRepository.GetEntityById(id);
            if(admin == null)
            {
                return null;
            }
            AdminGetDto adminGetDto = new AdminGetDto()
            {
                Id = id,
                Name = admin.Name,
                Surname = admin.Surname,
                Email = admin.Email,
            };
            return adminGetDto;
        }

        public void DeleteAdmin(AdminDeleteDto adminDeleteDto)
        {
            Admin? admin = _adminRepository.Table.Where(x => x.Id == adminDeleteDto.Id).FirstOrDefault();
            if(admin != null)
            {
                _adminRepository.Table.Remove(admin);
                _adminRepository.SaveChanges();
            }
        }

        public List<Admin> GetAllAdmins()
        {
            var admins = _adminRepository.Table.ToList();

            return admins;
        }

        /*public void AddDoctor(AdminAddDoctorDto adminAddDoctorDto)
        {
            Doctor doctor = new Doctor()
            {
                CreatedDate = DateTime.Now,
                Name = adminAddDoctorDto.Name,
                Surname = adminAddDoctorDto.Surname,
                Email = adminAddDoctorDto.Email,
                Password = adminAddDoctorDto.Password,
                BirthDate = adminAddDoctorDto.BirthDate,
                Gender = adminAddDoctorDto.Gender,
                PhoneNumber = adminAddDoctorDto.PhoneNumber,
                Adress = adminAddDoctorDto.Adress,
                SpecializationArea = adminAddDoctorDto.SpecializationArea,
                HospitalName = adminAddDoctorDto.HospitalName,
            };

            _doctorRepository.AddDoctor(doctor);
        }*/


    }
}
