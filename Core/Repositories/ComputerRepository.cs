using Core.Entities;

namespace Core.Repositories
{
    public class ComputerRepository : Repository<Computer>
    {
        public ComputerRepository(DbDataContext context) : base(context)
        {
        }
    }
}
