using System.Collections.Generic;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Delete(T item);
    }
}
