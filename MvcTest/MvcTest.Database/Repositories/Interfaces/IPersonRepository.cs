using System.Collections.Generic;
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
