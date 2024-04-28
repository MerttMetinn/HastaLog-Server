namespace PatientLog.Domain.Entities
{
    public class MedicalReport: BaseEntity
    {
        public DateTime Date { get; set; }
        public string Path { get; set; }
        public Patient PatientId { get; set; }
        public Doctor DoctorId { get; set; }
        public Appointment AppointmentId { get; set; }
    }
}
