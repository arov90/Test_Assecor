using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Assecor.Models
{
    //Model Class
    public class Person
    {
        [Index(0)]
        public int Id { get; set; }

        [Index(1)]
        public string Name { get; set; }

        [Index(2)]
        public string LastName { get; set; }

        [Index(3)]
        public string ZipCode { get; set; }

        [Index(4)]
        public string City { get; set; }

        [Index(5)]
        public string Color { get; set; }
    }
}