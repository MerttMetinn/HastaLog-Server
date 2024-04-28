using PatientLog.Domain.Dtos.AdminDtos;

namespace PatientLog.Service.Abstract
{
    public interface IAdminService
    {
        void AddAdmin(AdminAddDto adminAddDto);
    }
}
