using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleWebApp.Context;
using PeopleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly AzureDbContext db;

        public PeopleController(AzureDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var people = db.People.ToList();
            return Ok(people);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var findedPeople = db.People.FirstOrDefault(people => people.PersonId == id);
            if (findedPeople == null)
            {
                return BadRequest();
            }

            return Ok(findedPeople);
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }

            db.People.Add(person);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = person.PersonId}, person);
        }

        [HttpPut("{id:int}")]
        public IActionResult Modify(int id, Person person)
        {
            var findedPeople = db.People.FirstOrDefault(people => people.PersonId == id);
            if (findedPeople == null)
            {
                return BadRequest();
            }
            else 
            {
                findedPeople.FirstName = person.FirstName;
                findedPeople.LastName = person.LastName;
                db.SaveChanges();
            }

            return Ok(findedPeople);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var findedPeople = db.People.FirstOrDefault(people => people.PersonId == id);
            if (findedPeople == null)
            {
                return BadRequest();
            }
            else
            {
                db.People.Remove(findedPeople);
                db.SaveChanges();
            }

            return Ok(findedPeople);
        }
    }
}
