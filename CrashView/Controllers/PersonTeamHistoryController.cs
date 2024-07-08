using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrashView.Entities;
using CrashView.Dto.Request;
using AutoMapper;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTeamHistoryController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PersonTeamHistoryController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PersonTeamHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonTeamHistoryDto>>> GetPersonTeamHistory()
        {
            var personTeamHistories = await _context.PersonTeamHistory
                .Include(pth => pth.Person)
                .Include(pth => pth.Team)
                .ToListAsync();

            var response = _mapper.Map<List<PersonTeamHistoryDto>>(personTeamHistories);

            return Ok(response);
        }

        // GET: api/PersonTeamHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonTeamHistoryDto>> GetPersonTeamHistory(int id)
        {
            var personTeamHistory = await _context.PersonTeamHistory
                .Include(pth => pth.Person)
                .Include(pth => pth.Team)
                .FirstOrDefaultAsync(pth => pth.PersonTeamHistory_ID == id);

            if (personTeamHistory == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<PersonTeamHistoryDto>(personTeamHistory);

            return Ok(response);
        }

        // PUT: api/PersonTeamHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonTeamHistory(int id, [FromBody] PersonTeamHistoryDto personTeamHistoryDto)
        {
            if (id != personTeamHistoryDto.PersonTeamHistory_ID)
            {
                return BadRequest();
            }

            var personTeamHistory = _mapper.Map<PersonTeamHistory>(personTeamHistoryDto);

            _context.Entry(personTeamHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonTeamHistoryExists(id))
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

        // POST: api/PersonTeamHistory
        [HttpPost]
        public async Task<ActionResult<PersonTeamHistoryDto>> PostPersonTeamHistory([FromBody] PersonTeamHistoryDto personTeamHistoryDto)
        {
            var personTeamHistory = _mapper.Map<PersonTeamHistory>(personTeamHistoryDto);

            _context.PersonTeamHistory.Add(personTeamHistory);
            await _context.SaveChangesAsync();

            var responseDto = _mapper.Map<PersonTeamHistoryDto>(personTeamHistory);

            return CreatedAtAction(nameof(GetPersonTeamHistory), new { id = responseDto.PersonTeamHistory_ID }, responseDto);
        }

        // DELETE: api/PersonTeamHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonTeamHistory(int id)
        {
            var personTeamHistory = await _context.PersonTeamHistory.FindAsync(id);
            if (personTeamHistory == null)
            {
                return NotFound();
            }

            _context.PersonTeamHistory.Remove(personTeamHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonTeamHistoryExists(int id)
        {
            return _context.PersonTeamHistory.Any(e => e.PersonTeamHistory_ID == id);
        }
    }
}
