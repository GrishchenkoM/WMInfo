using System.Data.Entity;
using Core.Entities;

namespace Core
{
    public class DbDataContext : DbContext
    {
        public DbDataContext() : base("DbDataContext")
        { }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
