using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;
using System.Linq;

namespace PatientLog.Service.Concrete
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _repository;

        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }


        public void AddAdmin(AdminAddDto adminAddDto)
        {

            Admin admin = new Admin()
            {
                CreatedDate = DateTime.Now,
                Name = adminAddDto.Name,
                Password = adminAddDto.Password,
                Surname = adminAddDto.Surname,
            };

           //  _repository.AddEntity(admin);

            _repository.Table.Add(admin);

            _repository.SaveChanges();

        }

        public AdminGetDto? GetAdminById(int id)
        {
            var admin = _repository.GetEntityById(id);
            if(admin == null)
            {
                return null;
            }
            AdminGetDto adminGetDto = new AdminGetDto()
            {
                Id = id,
                Name = admin.Name,
                Surname = admin.Surname,
            };
            return adminGetDto;
        }

        public void DeleteAdmin(AdminDeleteDto adminDeleteDto)
        {
            Admin? admin = _repository.Table.Where(x => x.Id == adminDeleteDto.Id).FirstOrDefault();
            if(admin != null)
            {
                _repository.Table.Remove(admin);
                _repository.SaveChanges();
            }
        }

        public List<Admin> GetAllAdmins()
        {
            var admins = _repository.Table.ToList();

            return admins;
        }
    }
}
