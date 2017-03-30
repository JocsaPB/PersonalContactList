using PersonalContactList.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PersonalContactList.Domain.Entities
{
    public class Contact
    {
        public int ContatId { get; set; }
        public string Name { get; set; }
        public string KnownAs { get; set; }
        public Emails Emails { get; set; }
        public TelNumbers Numbers { get; set; }
        public Social Social { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public bool isOfEspecialCategory()
        {
            return this.Category.EspecialCategory;
        }
    }
}
