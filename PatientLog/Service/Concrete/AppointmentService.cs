using PatientLog.Domain.Dtos.AppointmentDtos;
using PatientLog.Domain.Entities;
using PatientLog.Service.Abstract;

namespace PatientLog.Service.Concrete
{
    public class AppointmentService : IAppointmentService
    {
        public void AddAppointment(AppointmentAddDto appointmentAddDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteAppointment(AppointmentDeleteDto appointmentDeleteDto)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public AppointmentGetDto? GetAppointmentById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
