using PatientLog.Domain.Dtos.TokenDtos;
using PatientLog.Service.Abstract;

namespace PatientLog.Service.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;

        public LoginService(ITokenService tokenService, IAdminService adminService, IDoctorService doctorService)
        {
            _tokenService = tokenService;
            _adminService = adminService;
            _doctorService = doctorService;
        }

 
        // patient
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {

            LoginResponse response = null;

            switch (loginRequest.UserType)
            {
                case Domain.Enums.UserTypeEnum.Admin:

                    var isExist = _adminService.CheckAdminExist(loginRequest.Email, loginRequest.Password);

                    if (isExist)
                    {
                        var admin = _adminService.GetAdminByEmail(loginRequest.Email);


                        var loginResponse = await _tokenService.CreateTokenAsync(new()
                        {
                            Email = admin.Email,
                            Id = admin.Id,
                            UserType = Domain.Enums.UserTypeEnum.Admin
                        });

                        response = loginResponse;

                    }
                    else
                    {
                        throw new Exception("Kullanıcı Bulunamadı.");
                    }


                    break;
                case Domain.Enums.UserTypeEnum.Doctor:
                    break;
                case Domain.Enums.UserTypeEnum.Patient:
                    break;
                default:
                    throw new Exception("Kullanıcı Bulunamadı.");
            }


            return response;
        }
    }
}
