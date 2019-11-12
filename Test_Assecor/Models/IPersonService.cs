using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Assecor.Models
{
    //Rest Interface
    public interface IPersonService
    {
        IEnumerable<Person> GetAllItems();
        Person GetById(int id);

        IEnumerable<Person> GetPersonsByColor(string color);
    }
}
