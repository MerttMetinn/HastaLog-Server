namespace PatientLog.Domain.Entities
{
    public class MedicalReport: BaseEntity
    {
        public DateTime Date { get; set; }
        public string Path { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
