using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Domain.Dtos.PatientDtos;
using PatientLog.Service.Abstract;
using PatientLog.Service.Concrete;

namespace PatientLog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientservice;

        public PatientsController(IPatientService patientService)
        {
            _patientservice = patientService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddPatient([FromBody] PatientAddDto patientAddDto)
        {
            _patientservice.AddPatient(patientAddDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePatient([FromRoute] Guid id)
        {
            PatientDeleteDto patientDeleteDto = new PatientDeleteDto()
            {
                Id = id
            };

            _patientservice.DeletePatient(patientDeleteDto);
            return Ok();
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetPatientById(Guid id)
        {
            try
            {
                var patient = _patientservice.GetPatientById(id);
                if (patient == null)
                {
                    return BadRequest("Patient not found");
                }
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllPatients()
        {
            var patients = _patientservice.GetAllPatients();

            if (patients == null || !patients.Any())
            {
                return NotFound("No patients found matching the provided criteria.");
            }

            return Ok(patients);
        }
    }
}
