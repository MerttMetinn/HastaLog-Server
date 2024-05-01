using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Service.Abstract;

namespace PatientLog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {

        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public IActionResult AddAdmin([FromBody]AdminAddDto adminAddDto)
        {
            _adminService.AddAdmin(adminAddDto);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAdminById([FromRoute]Guid id) 
        {
            try
            {
                var admin = _adminService.GetAdminById(id);
                if (admin == null)
                {
                    return BadRequest("Admin not found");
                }
                return Ok(admin);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin([FromRoute] Guid id)
        {
            AdminDeleteDto adminDeleteDto = new AdminDeleteDto()
            {
                Id = id
            };
            
            _adminService.DeleteAdmin(adminDeleteDto);
            return Ok();
          
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var admins = _adminService.GetAllAdmins();

            if (admins == null || !admins.Any())
            {
                return NotFound("No admins found matching the provided criteria.");
            }

            return Ok(admins);
        }

    }
}
