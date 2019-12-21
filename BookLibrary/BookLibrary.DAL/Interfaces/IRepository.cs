using System.Collections.Generic;

namespace BookLibrary.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Edit(T entity);

        void Delete(int id);

        T Get(int id);

        IEnumerable<T> Get();
    }
}
