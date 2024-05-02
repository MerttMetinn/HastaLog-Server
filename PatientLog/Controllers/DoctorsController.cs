using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Service.Abstract;
using PatientLog.Service.Concrete;
using System.Security.Claims;

namespace PatientLog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorservice;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorservice = doctorService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddDoctor([FromBody] DoctorAddDto doctorAddDto)
        {
            _doctorservice.AddDoctor(doctorAddDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteDoctor([FromRoute] Guid id)
        {
            DoctorDeleteDto doctorDeleteDto = new DoctorDeleteDto()
            {
                Id = id
            };

            _doctorservice.DeleteDoctor(doctorDeleteDto);
            return Ok();
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetDoctorById(Guid id)
        {
            try
            {
                var doctor = _doctorservice.GetDoctorById(id);
                if (doctor == null)
                {
                    return BadRequest("Admin not found");
                }
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllDoctors()
        {
            var doctors = _doctorservice.GetAllDoctors();

            if (doctors == null || !doctors.Any())
            {
                return NotFound("No doctors found matching the provided criteria.");
            }

            return Ok(doctors);
        }
    }
}
