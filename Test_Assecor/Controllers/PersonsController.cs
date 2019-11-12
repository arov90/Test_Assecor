using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_Assecor.Services;
using Test_Assecor.Models;
using System.Net.Http;

namespace Test_Assecor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {   

        private readonly ILogger<PersonsController> _logger;
        private readonly PersonsRepository _personRepository;
        private readonly IPersonService _service;
        List<Person> _person = new List<Person>();

        public PersonsController(ILogger<PersonsController> logger)
        {
            _logger = logger;
            _personRepository = new PersonsRepository();
        }

        //To get all the record form CSV file
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            return _personRepository.GetAllItems().ToList();
        }

        //To get individual record using by id(line number)
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            return _personRepository.GetById(id);
        }

        //To get all the record with the same favorite color
        [HttpGet("color/{color}")]
        public async Task<ActionResult<IEnumerable<Person>>> Get(string color)
        {
            return _personRepository.GetPersonsByColor(color).ToList();
        }

        //Post record
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Person>>> Post()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _personRepository.AddNewRecord().ToList();
        }
    }
}