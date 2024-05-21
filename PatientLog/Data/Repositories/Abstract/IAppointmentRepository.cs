using PatientLog.Domain.Dtos.AppointmentDtos;
using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Abstract
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        List<Appointment> GetAppointmentsByPatientId(Guid patientId);
        bool CheckAppointmentDate(AppointmentGetDto appointmentGetDto);

    }
}
