using CsvHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Assecor.Models;

namespace Test_Assecor.Services
{
    public class PersonsRepository : IPersonService
    {
        private readonly List<Person> _person  = new List<Person>();

        private readonly DbContext db = new DbContext();
   
        public PersonsRepository()
        {
            _person = db.GetPeople();
        }

        public PersonsRepository(List<Person> person)
        {
            _person = person;
        }

        //Get all records
        public IEnumerable<Person> GetAllItems()
        {
            return _person.ToList();
        }

        //Get record by id
        public Person GetById(int id)
        {
            return _person.Where(p => p.Id == id).FirstOrDefault();

        }

        //Get record by color
        public IEnumerable<Person> GetPersonsByColor(string color)
        {
            return _person.Where(p => p.Color == color).ToList();
        }

        //Add new record
        public IEnumerable<Person> AddNewRecord()
        {
            db.AddRecord();
            return _person.ToList();
        }


    }
}
