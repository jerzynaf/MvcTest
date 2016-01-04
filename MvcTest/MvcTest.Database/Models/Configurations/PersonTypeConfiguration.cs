using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.Database.Models.Configurations
{
    public class PersonTypeConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonTypeConfiguration()
        {
            Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            Property(d => d.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
