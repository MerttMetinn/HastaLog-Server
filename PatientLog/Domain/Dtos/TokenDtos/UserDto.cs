using PatientLog.Domain.Enums;

namespace PatientLog.Domain.Dtos.TokenDtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
