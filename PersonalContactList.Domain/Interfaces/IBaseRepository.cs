using System.Collections.Generic;

namespace PersonalContactList.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Delete(T obj);
    }
}
