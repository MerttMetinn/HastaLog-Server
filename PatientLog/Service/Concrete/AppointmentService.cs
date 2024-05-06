using PatientLog.Data.Repositories.Abstract;
using PatientLog.Data.Repositories.Concrete;
using PatientLog.Domain.Dtos.AdminDtos;
using PatientLog.Domain.Dtos.AppointmentDtos;
using PatientLog.Domain.Dtos.DoctorDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;

namespace PatientLog.Service.Concrete
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void AddAppointment(AppointmentAddDto appointmentAddDto)
        {
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
