using Microsoft.AspNetCore.Mvc;
using CrashView.Entities;
using CrashView.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericRepository<Person> _personRepository;

        public PersonController(IGenericRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _personRepository.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            await _personRepository.InsertAsync(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.Person_Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Person_Id)
            {
                return BadRequest();
            }
            await _personRepository.UpdateAsync(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _personRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
