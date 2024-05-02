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
                UpdatedDate = DateTime.Now,
            };

            _adminRepository.AddEntity(admin);
        }

        public AdminGetDto? GetAdminById(Guid id)
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
            Admin? admin = _adminRepository.GetEntityById(adminDeleteDto.Id);
            if(admin != null)
            {
                _adminRepository.DeleteEntity(admin);
            }
        }

        public List<Admin> GetAllAdmins()
        {
            var admins = _adminRepository.GetAllEntities();

            return admins;
        }

        public bool CheckAdminExist(string email, string password)
        {
            return _adminRepository.CheckAdminExist(email, password);
        }

        public AdminGetDto? GetAdminByEmail(string email)
        {
            var admin = _adminRepository.GetEntityByEmail(email);
            if (admin == null)
            {
                return null;
            }
            AdminGetDto adminGetDto = new AdminGetDto()
            {
                Id = admin.Id,
                Name = admin.Name,
                Surname = admin.Surname,
                Email = admin.Email,
            };
            return adminGetDto;
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
