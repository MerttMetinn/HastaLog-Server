using PatientLog.Domain.Enums;

namespace PatientLog.Domain.Dtos.TokenDtos
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
