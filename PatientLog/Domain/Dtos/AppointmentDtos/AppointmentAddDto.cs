using PatientLog.Domain.Entities;

namespace PatientLog.Domain.Dtos.AppointmentDtos
{
    public class AppointmentAddDto
    {
        public DateTime Date { get; set; }
        public string HospitalName { get; set; }
        public string Clinic { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
    }
}
