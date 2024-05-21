namespace PatientLog.Domain.Dtos.MedicalReportDtos
{
    public class MedicalReportGetDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Path { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid AppointmentId { get; set; }
        public string Details { get; set; }
    }
}
