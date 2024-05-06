using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Service.Abstract
{
    public interface IAdminService
    {
        void AddAdmin(AdminAddDto adminAddDto);
        void DeleteAdmin(AdminDeleteDto adminDeleteDto);
        List<Admin> GetAllAdmins();
        AdminGetDto? GetAdminById(Guid id);
        AdminGetDto? GetAdminByEmail(string email);
        bool CheckAdminExist(string email, string password);
    }
}
