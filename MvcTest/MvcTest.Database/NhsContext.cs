using System.Data.Entity;
using MvcTest.Database.Models;

namespace MvcTest.Database
{
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
