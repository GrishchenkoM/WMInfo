using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.Entities;

namespace Core.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbDataContext _context;

        protected Repository(DbDataContext context)
        {
            _context = context;
        }

        public virtual List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T Create(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public virtual T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public virtual int Delete(T obj)
        {
            if (_context.Set<T>().Find(obj.Id) != null)
                _context.Set<T>().Remove(obj);

            return _context.SaveChanges();
        }
    }
}
