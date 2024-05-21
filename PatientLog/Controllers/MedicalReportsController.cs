using Microsoft.AspNetCore.Mvc;
using PatientLog.Domain.Dtos.MedicalReportDtos;
using PatientLog.Service.Abstract;

namespace PatientLog.Controllers
{
    
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class MedicalReportController : ControllerBase
        {
            private readonly IMedicalReportService _medicalReportService;

            public MedicalReportController(IMedicalReportService medicalReportService)
            {
                _medicalReportService = medicalReportService;
            }

            [HttpPost]
            //[Authorize(Roles = "admin")]
            public IActionResult AddMedicalReport([FromBody] MedicalReportAddDto medicalReportAddDto)
            {
                _medicalReportService.AddMedicalReport(medicalReportAddDto);
                return Ok();
            }

            [HttpDelete("{id}")]
            //[Authorize(Roles = "admin")]
            public IActionResult DeleteMedicalReport([FromRoute] Guid id)
            {
                var medicalReport = _medicalReportService.GetMedicalReportById(id);

                if (medicalReport == null)
                {
                    return BadRequest("Medical report not found");
                }

                var medicalReportDeleteDto = new MedicalReportDeleteDto { Id = id };
                _medicalReportService.DeleteMedicalReport(medicalReportDeleteDto);
                return Ok();
            }

            [HttpGet("{id}")]
            //[Authorize(Roles = "admin")]
            public IActionResult GetMedicalReportById(Guid id)
            {
                try
                {
                    var medicalReport = _medicalReportService.GetMedicalReportById(id);
                    if (medicalReport == null)
                    {
                        return BadRequest("Medical report not found");
                    }
                    return Ok(medicalReport);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
                }
            }

            [HttpGet]
            //[Authorize(Roles = "admin")]
            public IActionResult GetAllMedicalReports()
            {
                var medicalReports = _medicalReportService.GetAllMedicalReports();

                if (medicalReports == null || !medicalReports.Any())
                {
                    return NotFound("No medical reports found.");
                }

                var medicalReportDtos = medicalReports.Select(m => new MedicalReportGetDto
                {
                    Id = m.Id,
                    Date = m.Date,
                    Path = m.Path,
                    PatientId = m.PatientId,
                    DoctorId = m.DoctorId,
                    AppointmentId = m.AppointmentId,
                    Details = m.Details
                }).ToList();

                return Ok(medicalReportDtos);
            }
        
    }
}
