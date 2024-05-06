using PatientLog.Data.Repositories.Abstract;
using PatientLog.Data.Repositories.Concrete;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Dtos.AppointmentDtos;
using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;
using System.Collections.Generic;

namespace PatientLog.Service.Concrete
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _petientService;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorService doctorService, IPatientService petientService)
        {
            _appointmentRepository = appointmentRepository;
            _doctorService = doctorService;
            _petientService = petientService;
        }

        public  void AddAppointment(AppointmentAddDto appointmentAddDto)
        {

            var doctor =  _doctorService.GetDoctorById(appointmentAddDto.DoctorId);

            if(doctor == null)
            {
                throw new Exception("Doktor bulunamadı.");
            }

            // -> patient

            Appointment appointment = new Appointment()
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PatientId = appointmentAddDto.PatientId,
                DoctorId = appointmentAddDto.DoctorId,
                HospitalName = appointmentAddDto.HospitalName,
                Date = appointmentAddDto.Date,
            };
            _appointmentRepository.AddEntity(appointment);
        }

        public void DeleteAppointment(AppointmentDeleteDto appointmentDeleteDto)
        {
            Appointment? appointment = _appointmentRepository.GetEntityById(appointmentDeleteDto.Id);
            if (appointment != null)
            {
                _appointmentRepository.DeleteEntity(appointment);
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAllEntities();

            return appointments;
        }

        public List<AppointmentGetDto> GetAllAppointmentsByPatientId(Guid patientId)
        {
            var appointments = _appointmentRepository.GetAllAppointmentByPatientId(patientId);

            List<AppointmentGetDto> result = new();

            foreach (Appointment appointment in appointments)
            {
                AppointmentGetDto appointmentGetDto = new()
                {
                    PatientId = appointment.PatientId,
                    Date = appointment.Date,
                    DoctorId = appointment.DoctorId,
                    HospitalName = appointment.HospitalName,
                    Id = appointment.Id
                };

                result.Add(appointmentGetDto);

            }

            // yontem 2

            //var reult2 = appointments.Select(appointment =>
            //{
            //    return new AppointmentGetDto()
            //    {
            //        PatientId = appointment.PatientId,
            //        Date = appointment.Date,
            //        DoctorId = appointment.DoctorId,
            //        HospitalName = appointment.HospitalName,
            //        Id = appointment.Id
            //    };
            //}).ToList();

            return result;
        }

        public AppointmentGetDto? GetAppointmentById(Guid id)
        {
            var appointment = _appointmentRepository.GetEntityById(id);
            if (appointment == null)
            {
                return null;
            }
            AppointmentGetDto appointmentGetDto = new AppointmentGetDto()
            {
                Id = id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                HospitalName = appointment.HospitalName,
                Date = appointment.Date,
            };
            return appointmentGetDto;
        }
    }
}
