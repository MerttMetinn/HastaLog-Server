using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Data.Repositories.Concrete;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Dtos.AppointmentDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;
using PatientLog.Service.Concrete;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        //[Authorize(Roles = "admin,patient")]
        public IActionResult AddAppointment([FromBody] AppointmentAddDto appointmentAddDto)
        {
            if (appointmentAddDto == null)
            {
                return BadRequest("Appointment data is null.");
            }

            // Check if an appointment already exists for the given date and time
            var appointmentCheckDto = new AppointmentGetDto
            {
                Date = appointmentAddDto.Date,
                HospitalName = appointmentAddDto.HospitalName,
                Clinic = appointmentAddDto.Clinic,
                PatientId = appointmentAddDto.PatientId,
                DoctorId = appointmentAddDto.DoctorId
            };

            bool exists = _appointmentservice.CheckAppointmentDate(appointmentCheckDto);

            if (exists)
            {
                return BadRequest("Bu tarihli bir randevu zaten mevcut !");
            }

            // Add the appointment if no conflict
            _appointmentservice.AddAppointment(appointmentAddDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin,patient")]
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
        //[Authorize(Roles = "patient")]
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
        //[Authorize(Roles = "admin")]
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentservice.GetAllAppointments();

            if (appointments == null || !appointments.Any())
            {
                return NotFound("No appointments found matching the provided criteria.");
            }

            return Ok(appointments);
        }

        [HttpPost("CheckAppointmentDate")]
        //[Authorize(Roles = "admin,patient")]
        public IActionResult CheckAppointmentDate([FromBody] AppointmentGetDto appointmentGetDto)
        {
            if (appointmentGetDto == null)
            {
                return BadRequest("Appointment data is null.");
            }

            bool exists = _appointmentservice.CheckAppointmentDate(appointmentGetDto);

            if (exists)
            {
                return BadRequest("An appointment already exists for the given date and time.");

            }
            else
            {
                return Ok();
            }
        }


        [HttpGet("patient/{patientId}")]
        public IActionResult GetAppointmentsByPatientId(Guid patientId)
        {
            try
            {
                var appointments = _appointmentservice.GetAppointmentsByPatientId(patientId);
                if (appointments == null || appointments.Count == 0)
                {
                    return NotFound();
                }
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(500, "Internal server error");
            }
        }


    }
}