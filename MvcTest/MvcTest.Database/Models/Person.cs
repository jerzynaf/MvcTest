using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTest.Database.Models
{
    public partial class Person
    {
        public Person()
        {
            Colours = new HashSet<Colour>();
        }

        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAuthorised { get; set; }

        public bool IsValid { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<Colour> Colours { get; set; }
    }
}
