using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [UIHint("YesNo")]
        public bool IsAuthorised { get; set; }

        public bool IsValid { get; set; }

        [UIHint("YesNo")]
        public bool IsEnabled { get; set; }

        public List<ColourViewModel> Colours { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string ColoursString
        {
            get
            {
                return string.Join(", ", Colours.OrderBy(c => c.Name).Select(c => c.Name)).TrimEnd(new char[] { ',', ' ' });
            }
        }

        [UIHint("YesNo")]
        public bool IsPalindrome
        {
            get
            {
                var fullName = FirstName.ToUpper() + LastName.ToUpper();
                for (int i = 0; i < fullName.Length; i++)
                {
                    if (!fullName[i].Equals(fullName[fullName.Length - i - 1]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
