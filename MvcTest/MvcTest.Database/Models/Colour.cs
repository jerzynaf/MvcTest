using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTest.Database.Models
{
    public partial class Colour
    {
        public Colour()
        {
            People = new HashSet<Person>();
        }

        public int ColourId { get; set; }

        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
