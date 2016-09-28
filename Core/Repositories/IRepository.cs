using System.Collections.Generic;
using Core.Entities;

namespace Core.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        List<T> Get();
        T Get(int id);
        T Create(T obj);
        T Update(T obj);
        int Delete(T obj);
    }
}
