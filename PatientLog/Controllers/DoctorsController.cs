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
    }
}
