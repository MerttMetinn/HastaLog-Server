namespace PatientLog.Domain.Dtos.AppointmentDtos
{
    public class AppointmentGetDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string HospitalName { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
    }
}
