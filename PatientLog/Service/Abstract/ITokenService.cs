using PatientLog.Domain.Dtos.TokenDtos;

namespace PatientLog.Service.Abstract
{
    public interface ITokenService
    {
        Task<LoginResponse> CreateTokenAsync(UserDto user);
    }
}
