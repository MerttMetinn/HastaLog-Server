using PatientLog.Domain.Dtos.AppointmentDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Service.Abstract
{
    public interface IAppointmentService
    {
        void AddAppointment(AppointmentAddDto appointmentAddDto);
        void DeleteAppointment(AppointmentDeleteDto appointmentDeleteDto);
        List<Appointment> GetAllAppointments();
        AppointmentGetDto? GetAppointmentById(Guid id);
    }
}
