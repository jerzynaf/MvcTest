using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTest.Database.Interfaces;
using MvcTest.Database.Models;
using MvcTest.Database.Repositories.Interfaces;

namespace MvcTest.Database.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly INhsContext _context;

        public PersonRepository(INhsContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.People.OrderBy(p => p.FirstName);
        }

        public Person GetPerson(int id)
        {
            return _context.People.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
