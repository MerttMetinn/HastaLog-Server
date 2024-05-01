namespace PatientLog.Domain.Entities
{
    public class RoleUser: BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
