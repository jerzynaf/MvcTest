using MvcTest.Web.Database.Models;

namespace MvcTest.Web.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NhsContext : DbContext
    {
        public NhsContext()
            : base("name=NhsContext")
        {
        }

        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colour>()
                .HasMany(e => e.People)
                .WithMany(e => e.Colours)
                .Map(m => m.ToTable("FavouriteColours").MapLeftKey("ColourId").MapRightKey("PersonId"));
        }
    }
}
