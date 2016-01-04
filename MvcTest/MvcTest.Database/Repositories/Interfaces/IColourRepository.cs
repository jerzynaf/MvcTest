using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTest.Database.Interfaces;
using MvcTest.Database.Models;

namespace MvcTest.Database.Repositories.Interfaces
{
    public interface IColourRepository
    {
        IEnumerable<Colour> GetAllColours();
        Colour GetColour(int id);
    }
}
