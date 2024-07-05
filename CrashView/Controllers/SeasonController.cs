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
    public class SeasonController : ControllerBase
    {
        private readonly DataContext _context;

        public SeasonController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Season
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Season>>> GetSeasons()
        {
            return await _context.Season.ToListAsync();
        }

        // GET: api/Season/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Season>> GetSeason(int id)
        {
            var season = await _context.Season.FindAsync(id);

            if (season == null)
            {
                return NotFound();
            }

            return season;
        }

        // PUT: api/Season/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeason(int id, Season season)
        {
            if (id != season.Season_ID)
            {
                return BadRequest();
            }

            _context.Entry(season).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(id))
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

        // POST: api/Season
        [HttpPost]
        public async Task<ActionResult<Season>> PostSeason(Season season)
        {
            _context.Season.Add(season);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeason), new { id = season.Season_ID }, season);
        }

        // DELETE: api/Season/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            var season = await _context.Season.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }

            _context.Season.Remove(season);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeasonExists(int id)
        {
            return _context.Season.Any(e => e.Season_ID == id);
        }
    }
}
