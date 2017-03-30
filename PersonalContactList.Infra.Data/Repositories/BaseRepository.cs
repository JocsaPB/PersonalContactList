using PersonalContactList.Domain.Interfaces;
using PersonalContactList.Infra.Data.Context;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace PersonalContactList.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected PersonalContactListContext Db = new PersonalContactListContext();

        public void Add(T obj)
        {
            Db.Set<T>().Add(obj);
            Db.SaveChanges();
        }
        public void Update(T obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
        
        public IEnumerable<T> FindAll()
        {
            return Db.Set<T>().ToList();
        }

        public T FindById(int id)
        {
            return Db.Set<T>().Find(id);
        }
        public void Delete(T obj)
        {
            Db.Set<T>().Remove(obj);
            Db.SaveChanges();
        }

    }
}
