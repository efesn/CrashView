using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrashView.Entities;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTeamHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonTeamHistoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PersonTeamHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonTeamHistory>>> GetPersonTeamHistory()
        {
            return await _context.PersonTeamHistory.ToListAsync();
        }

        // GET: api/PersonTeamHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonTeamHistory>> GetPersonTeamHistory(int id)
        {
            var personTeamHistory = await _context.PersonTeamHistory.FindAsync(id);

            if (personTeamHistory == null)
            {
                return NotFound();
            }

            return personTeamHistory;
        }

        // PUT: api/PersonTeamHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonTeamHistory(int id, [FromBody] PersonTeamHistory personTeamHistory)
        {
            if (id != personTeamHistory.PersonTeamHistory_ID)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<PersonTeamHistory>> PostPersonTeamHistory([FromBody] PersonTeamHistory personTeamHistory)
        {
            _context.PersonTeamHistory.Add(personTeamHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonTeamHistory), new { id = personTeamHistory.PersonTeamHistory_ID }, personTeamHistory);
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
