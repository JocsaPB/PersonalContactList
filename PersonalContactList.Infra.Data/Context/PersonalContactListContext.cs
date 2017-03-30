using PersonalContactList.Domain.Entities;
using PersonalContactList.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PersonalContactList.Infra.Data.Context
{
    public class PersonalContactListContext : DbContext
    {
        public PersonalContactListContext()
            //set conection string
            :base("PersonalContactList")
        {}

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //exclude the pluralization at name of the tables
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remove the convention to the cascade delete
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //set the columns string as varchar
            modelBuilder.Properties<string>()
                .Configure(t => t.HasColumnType("varchar"));
            //set the string length to 30 char. If wanna to change it, must do it in the EntityConfig
            modelBuilder.Properties<string>()
                .Configure(t => t.HasMaxLength(30));

            //add configuration files to the modelBuilder to execute it
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
