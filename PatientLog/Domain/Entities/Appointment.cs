namespace PatientLog.Domain.Entities
{
    public class Appointment: BaseEntity
    {
        public Appointment()
        {
            MedicalReports = new List<MedicalReport>();
        }
        public DateTime Date { get; set; }
        public string HospitalName { get; set; }
        public string Clinic { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<MedicalReport> MedicalReports { get; set; }
    }
}
