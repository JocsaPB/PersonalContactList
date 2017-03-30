using PersonalContactList.Domain.Entities;
using System.Collections.Generic;

namespace PersonalContactList.Domain.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        IEnumerable<Contact> FindAllByCategory(int categoryId);
    }
}
