using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTest.Models.ViewModels
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsAuthorised { get; set; }

        public bool IsValid { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<ColourViewModel> Colours { get; set; }
    }
}
