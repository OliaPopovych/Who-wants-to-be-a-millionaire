using System.Collections.Generic;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
