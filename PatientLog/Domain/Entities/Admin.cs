namespace PatientLog.Domain.Entities
{
    public class Admin: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}
