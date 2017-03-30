
using PersonalContactList.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PersonalContactList.Infra.Data.EntityConfig
{
    class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(c => c.CategoryID);

            Property(c => c.CategoryName)
                .IsRequired();
        }
    }
}
