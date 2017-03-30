using PersonalContactList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalContactList.Infra.Data.EntityConfig
{
    class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            HasKey(c => c.ContatId);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(80);

            Property(c => c.KnownAs)
                .IsRequired();

            Property(c => c.Numbers.TelNumberA)
                .IsRequired();

            Property(c => c.CategoryId)
                .IsRequired();

            HasRequired(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId);

        }
    }
}
