using CrashView.Data.Repositories;
using CrashView.Dto.Response;
using CrashView.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IMapper _mapper;

        public PersonController(IGenericRepository<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonsResponseDto>>> GetPersons()
        {
            // todo: | Role ve Team bilgilerinin gelebilmesi için Generic Repository'e eklememiz gereken konunun araştırılarak bulunup eklenmesi
                // (Eager Loading?)
            
            //var persons = await _personRepository.GetAllAsync();
            var persons = await _personRepository.GetAllAsync(p => p.Role, p => p.Team);

            // todo: | Bu kısım yerine AutoMapper araştırılması:

            //List<PersonsResponseDto> result = [];

            //foreach (var item in persons)
            //{
            //    result.Add(new PersonsResponseDto
            //    {
            //        Age = item.Age,
            //        First_Name = item.First_Name,
            //        Last_Name = item.Last_Name,
            //        Nationality = item.Nationality,
            //        Person_Id = item.Person_Id
            //    });
            //}

            var result = _mapper.Map<List<PersonsResponseDto>>(persons);

            return Ok(result);
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

        [HttpPost("PostPerson")]
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
