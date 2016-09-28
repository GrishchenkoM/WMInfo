using System.Data.Entity;
using Core.Entities;

namespace Core
{
    public class DbDataContext : DbContext
    {
        // before adding dependency injection (Autofac)
        //public DbDataContext() : base(ConfigurationManager.ConnectionStrings[1].ConnectionString) { }
        public DbDataContext() : base("DefaultConnection") { }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
