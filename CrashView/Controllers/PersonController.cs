using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrashView.Entities;
using CrashView.Dto.Request;
using AutoMapper;
using CrashView.Validators;
using FluentValidation;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly PersonValidator _validator;

        public PersonController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _validator = new PersonValidator();
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonsResponseDto>>> GetPersons()
        {
            var persons = await _context.Persons
                .Include(p => p.Role)
                .Include(p => p.Team)
                .ToListAsync();

            var response = _mapper.Map<List<PersonsResponseDto>>(persons);

            return Ok(response);
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonsResponseDto>> GetPerson(int id)
        {
            var person = await _context.Persons
                .Include(p => p.Role)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(p => p.Person_Id == id);

            if (person == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<PersonsResponseDto>(person);

            return Ok(response);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, [FromBody] PersonsResponseDto request)
        {
            if (id != request.Person_Id)
            {
                return BadRequest();
            }

            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _mapper.Map(request, person);

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Person
        [HttpPost]
        public async Task<ActionResult<PersonsResponseDto>> PostPerson(PersonsRequestDto request)
        {
            var validator = new PersonValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var person = _mapper.Map<Person>(request);

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<PersonsResponseDto>(person);

            return CreatedAtAction(nameof(GetPerson), new { id = person.Person_Id }, response);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Person_Id == id);
        }
    }
}
