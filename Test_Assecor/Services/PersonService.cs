using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Assecor.Models;

namespace Test_Assecor.Services
{
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetPersonsByColor(string color)
        {
            throw new NotImplementedException();
        }
    }
}
