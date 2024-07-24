using System.Collections.Generic;

namespace OnionArchitectureImplementation.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
