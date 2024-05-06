using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Dtos.AppointmentDtos;
using PatientLog.Service.Abstract;
using System.Security.Claims;

namespace PatientLog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentservice;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentservice = appointmentService;
        }

        [HttpPost]
        [Authorize(Roles = "patient")]
        public IActionResult AddAppointment([FromBody] AppointmentAddDto appointmentAddDto)
        {
            _appointmentservice.AddAppointment(appointmentAddDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "patient")]
        public IActionResult DeleteAppointment([FromRoute] Guid id)
        {
            AppointmentDeleteDto appointmentDeleteDto = new AppointmentDeleteDto()
            {
                Id = id
            };

            _appointmentservice.DeleteAppointment(appointmentDeleteDto);
            return Ok();
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "patient")]
        public IActionResult GetAppointmentById(Guid id)
        {
            try
            {
                var appointment = _appointmentservice.GetAppointmentById(id);
                if (appointment == null)
                {
                    return BadRequest("Appointment not found");
                }
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Authorize(Roles = "patient")]
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentservice.GetAllAppointments();

            if (appointments == null || !appointments.Any())
            {
                return NotFound("No appointments found matching the provided criteria.");
            }

            return Ok(appointments);
        }
    }
}
