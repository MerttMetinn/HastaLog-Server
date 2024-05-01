using PatientLog.Domain.Enums;

namespace PatientLog.Domain.Dtos.TokenDtos
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
