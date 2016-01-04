using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTest.Database.Models;

namespace MvcTest.Database.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPerson(int id);
        void SaveChanges();
    }
}
