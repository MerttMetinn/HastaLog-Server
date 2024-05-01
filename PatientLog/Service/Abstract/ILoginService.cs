using PatientLog.Domain.Dtos.TokenDtos;

namespace PatientLog.Service.Abstract
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
