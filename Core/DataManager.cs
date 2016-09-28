using Core.Entities;
using Core.Repositories;

namespace Core
{
    public class DataManager : IDataManager
    {
        private ComputerRepository _computerRepository;
        private ManufacturerRepository _manufacturerRepository;
        private UserRepository _userRepository;
        private readonly DbDataContext _context;

        public DataManager()
        {
            _context = new DbDataContext();
        }

        public DataManager(ComputerRepository computerRepository,
            ManufacturerRepository manufacturerRepository,
            UserRepository userRepository, DbDataContext context)
        {
            _computerRepository = computerRepository;
            _manufacturerRepository = manufacturerRepository;
            _userRepository = userRepository;
            _context = context;
        }

        public Repository<Computer> Computers
        {
            get { return _computerRepository ?? (_computerRepository = new ComputerRepository(_context)); }
        }

        public Repository<Manufacturer> Manufacturers
        {
            get { return _manufacturerRepository ?? (_manufacturerRepository = new ManufacturerRepository(_context)); }
        }

        public Repository<User> Users
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }
    }
}
