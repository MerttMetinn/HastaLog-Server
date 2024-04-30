using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Service.Abstract
{
    public interface IAdminService
    {
        void AddAdmin(AdminAddDto adminAddDto);
        AdminGetDto? GetAdminById(int id);
        void DeleteAdmin(AdminDeleteDto adminDeleteDto);
        List<Admin> GetAllAdmins();
        //void AddDoctor(AdminAddDoctorDto adminAddDoctorDto);
    }
}
