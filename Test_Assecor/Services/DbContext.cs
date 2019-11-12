using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test_Assecor.Models;
using System.Text;

namespace Test_Assecor.Services
{
    public class DbContext
    {
        private readonly List<Person> _person = new List<Person>();
        TextReader reader = new StreamReader("People.csv", Encoding.UTF7); //CSV file path
        
        //Color coverter
        public string ColorConverterToString(string colorID)
        {
            string colorName;

            if (colorID == "1")
            {
                colorName = "blue";
            }
            else if (colorID == "2")
            {
                colorName = "green";
            }
            else if (colorID == "3")
            {
                colorName = "purple";
            }
            else if (colorID == "4")
            {
                colorName = "red";
            }
            else if (colorID == "5")
            {
                colorName = "yellow";
            }
            else if (colorID == "6")
            {
                colorName = "turquois";
            }
            else if (colorID == "7")
            {
                colorName = "white";
            }
            else
            {
                colorName = "no color match";
            }
            return colorName;
        }

        //Add all records in a list object and return it
        public List<Person> GetPeople()
        {
            var csvReader = new CsvReader(reader);
            csvReader.Configuration.HasHeaderRecord = false;
            csvReader.Configuration.HeaderValidated = null;
            csvReader.Configuration.MissingFieldFound = null;

            var rowCount = 0;
            while (csvReader.Read())
            {
                Person people = new Person();
                people.Id = rowCount + 1;
                people.Name = csvReader.GetField<string>(0);
                people.LastName = csvReader.GetField<string>(1);

                string[] address = csvReader.GetField<string>(2).Split(' ');
                string zip = address[0];
                string city = address[1];

                people.ZipCode = zip;
                people.City = city;
                people.Color = ColorConverterToString(csvReader.GetField<string>(3));

                _person.Add(people);
                rowCount++;
            }

            return _person;
        }

        //New record Insertion method
        public void AddRecord()
        {
            var addRecord = new List<Person>();
            addRecord.Add(new Person { Name = "Mahbub Al", LastName = "Hasan", ZipCode = "52074", City = "Aachen", Color = "Blue" });
            addRecord.Add(new Person { Name = "Mölli", LastName = "Hasan", ZipCode = "52074", City = "Aachen", Color = "Blue" });

            using (var writer = new StreamWriter("People.csv"))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(addRecord);
            }
        }
    }
}
