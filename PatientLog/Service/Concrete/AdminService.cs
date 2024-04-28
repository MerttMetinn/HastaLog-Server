using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;

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
    }
}
