namespace PatientLog.Domain.Entities
{
    public class MedicalReport: BaseEntity
    {
        public DateTime Date { get; set; }
        public string Path { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
