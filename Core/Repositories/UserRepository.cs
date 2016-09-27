using Core.Entities;

namespace Core.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbDataContext context) : base(context)
        {
        }
    }
}
