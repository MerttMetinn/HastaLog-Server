using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Service.Abstract
{
    public interface IAdminService
    {
        void AddAdmin(AdminAddDto adminAddDto);
        AdminGetDto? GetAdminById(Guid id);
        AdminGetDto? GetAdminByEmail(string email);
        void DeleteAdmin(AdminDeleteDto adminDeleteDto);
        List<Admin> GetAllAdmins();
        bool CheckAdminExist(string email, string password);

        //void AddDoctor(AdminAddDoctorDto adminAddDoctorDto);
    }
}
