using Microsoft.AspNetCore.Mvc;
using PatientLog.Service.Abstract;

namespace PatientLog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthsController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Domain.Dtos.TokenDtos.LoginRequest loginRequest)
        {
            var response = await _loginService.Login(loginRequest);

            return Ok(response);
        }
    }
}
