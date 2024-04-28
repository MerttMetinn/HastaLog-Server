using PatientLog.Data.Contexts;
using PatientLog.Data.Repositories.Abstract;
using PatientLog.Domain.Entities;

namespace PatientLog.Data.Repositories.Concrete
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AppDbContext context) : base(context)
        {
        }

        public void ChangeUserPassword(int userId, string password)
        {
            throw new NotImplementedException();
        }
    }
}
