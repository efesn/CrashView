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
    public class RaceController : ControllerBase
    {
        private readonly DataContext _context;

        public RaceController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Race
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetRaces()
        {
            return await _context.Races.ToListAsync();
        }

        // GET: api/Race/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(int id)
        {
            var race = await _context.Races.FindAsync(id);

            if (race == null)
            {
                return NotFound();
            }

            return race;
        }

        // PUT: api/Race/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(int id, [FromBody] Race race)
        {
            if (id != race.Race_ID)
            {
                return BadRequest();
            }

            _context.Entry(race).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
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

        // POST: api/Race
        [HttpPost]
        public async Task<ActionResult<Race>> PostRace([FromBody] Race race)
        {
            _context.Races.Add(race);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRace), new { id = race.Race_ID }, race);
        }

        // DELETE: api/Race/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var race = await _context.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            _context.Races.Remove(race);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceExists(int id)
        {
            return _context.Races.Any(e => e.Race_ID == id);
        }
    }
}
