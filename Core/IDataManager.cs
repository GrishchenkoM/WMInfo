using Core.Entities;
using Core.Repositories;

namespace Core
{
    public interface IDataManager
    {
        Repository<Computer> Computers { get; }
        Repository<Manufacturer> Manufacturers { get; }
        Repository<User> Users { get; }
    }
}
