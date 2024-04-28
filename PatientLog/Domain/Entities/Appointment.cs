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
        public Patient PatientId { get; set; }
        public Doctor DoctorId { get; set; }
        public List<MedicalReport> MedicalReports { get; set; }
    }
}
