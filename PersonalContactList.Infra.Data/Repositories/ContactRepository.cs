using System;
using System.Collections.Generic;
using PersonalContactList.Domain.Entities;
using PersonalContactList.Domain.Interfaces;
using System.Linq;

namespace PersonalContactList.Infra.Data.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public IEnumerable<Contact> FindAllByCategory(int categoryId)
        {
            return Db.Contacts.Where(c => c.CategoryId == categoryId);
        }
    }
}
