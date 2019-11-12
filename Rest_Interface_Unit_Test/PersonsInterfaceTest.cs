using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Test_Assecor.Controllers;
using Test_Assecor.Models;
using Test_Assecor.Services;
using Xunit;

namespace Rest_Interface_Unit_Test
{
    public class PersonsInterfaceTest
    {
        IPersonService _service;
        public PersonsInterfaceTest()
        {
            var test = GetTestPeople();
            _service = new PersonsRepository(test);
        }

        [Fact]
        public void GetAllUsersTest()
        {
            // Act
            var actualResult = _service.GetAllItems();
            var expectedResult = GetTestPeople();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        private List<Person> GetTestPeople()
        {
            var testPerson = new List<Person>();
            testPerson.Add(new Person { Id = 1, Name = "Mahbub Al", LastName= "Hasan", ZipCode = "52074", City = "Aachen", Color = "Blue" });
            testPerson.Add(new Person { Id = 2, Name = "Mahbub", LastName = "Bhuyan", ZipCode = "45369", City = "Essen", Color = "Green" });
            testPerson.Add(new Person { Id = 3, Name = "Christian", LastName = "Müller", ZipCode = "52076", City = "Aachen", Color = "White" });
            testPerson.Add(new Person { Id = 4, Name = "Mölli", LastName = "Hasan", ZipCode = "52074", City = "Aachen", Color = "Blue" });

            return testPerson;
        }
    }
}
