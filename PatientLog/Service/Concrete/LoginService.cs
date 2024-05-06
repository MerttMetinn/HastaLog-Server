using PatientLog.Domain.Dtos.TokenDtos;
using PatientLog.Service.Abstract;

namespace PatientLog.Service.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public LoginService(ITokenService tokenService, IAdminService adminService, IDoctorService doctorService, IPatientService patientService)
        {
            _tokenService = tokenService;
            _adminService = adminService;
            _doctorService = doctorService;
            _patientService = patientService;
        }
 
        // patient
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            LoginResponse response = null;

            switch (loginRequest.UserType)
            {
                case Domain.Enums.UserTypeEnum.Admin:

                    var isExistAdmin = _adminService.CheckAdminExist(loginRequest.Email, loginRequest.Password);

                    if (isExistAdmin)
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

                    var isExistDoctor = _doctorService.CheckDoctorExist(loginRequest.Email, loginRequest.Password);

                    if (isExistDoctor)
                    {
                        var doctor = _doctorService.GetDoctorByEmail(loginRequest.Email);

                        var loginResponse = await _tokenService.CreateTokenAsync(new()
                        {
                            Email = doctor.Email,
                            Id = doctor.Id,
                            UserType = Domain.Enums.UserTypeEnum.Doctor
                        });

                        response = loginResponse;

                    }
                    else
                    {
                        throw new Exception("Kullanıcı Bulunamadı.");
                    }
                    break;
                case Domain.Enums.UserTypeEnum.Patient:

                    var isExistPatient = _patientService.CheckPatientExist(loginRequest.Email, loginRequest.Password);

                    if (isExistPatient)
                    {
                        var patient = _patientService.GetPatientByEmail(loginRequest.Email);

                        var loginResponse = await _tokenService.CreateTokenAsync(new()
                        {
                            Email = patient.Email,
                            Id = patient.Id,
                            UserType = Domain.Enums.UserTypeEnum.Doctor
                        });

                        response = loginResponse;

                    }
                    else
                    {
                        throw new Exception("Kullanıcı Bulunamadı.");
                    }
                    break;
                default:
                    throw new Exception("Kullanıcı Bulunamadı.");
            }


            return response;
        }
    }
}
