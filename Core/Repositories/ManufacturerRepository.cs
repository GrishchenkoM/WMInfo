using Core.Entities;

namespace Core.Repositories
{
    public class ManufacturerRepository : Repository<Manufacturer>
    {
        public ManufacturerRepository(DbDataContext context) : base(context)
        {
        }
    }
}
