namespace PatientLog.Domain.Dtos.PatientDtos
{
    public class PatientGetDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Path { get; set; }
    }
}
