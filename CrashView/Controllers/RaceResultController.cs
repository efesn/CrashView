using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrashView.Entities;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceResultController : ControllerBase
    {
        private readonly DataContext _context;

        public RaceResultController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RaceResult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceResult>>> GetRaceResults()
        {
            return await _context.RaceResults.ToListAsync();
        }

        // GET: api/RaceResult/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceResult>> GetRaceResult(int id)
        {
            var raceResult = await _context.RaceResults.FindAsync(id);

            if (raceResult == null)
            {
                return NotFound();
            }

            return raceResult;
        }

        // PUT: api/RaceResult/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceResult(int id, RaceResult raceResult)
        {
            if (id != raceResult.RaceResult_ID)
            {
                return BadRequest();
            }

            _context.Entry(raceResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceResultExists(id))
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

        // POST: api/RaceResult
        [HttpPost]
        public async Task<ActionResult<RaceResult>> PostRaceResult(RaceResult raceResult)
        {
            _context.RaceResults.Add(raceResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRaceResult), new { id = raceResult.RaceResult_ID }, raceResult);
        }

        // DELETE: api/RaceResult/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaceResult(int id)
        {
            var raceResult = await _context.RaceResults.FindAsync(id);
            if (raceResult == null)
            {
                return NotFound();
            }

            _context.RaceResults.Remove(raceResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceResultExists(int id)
        {
            return _context.RaceResults.Any(e => e.RaceResult_ID == id);
        }
    }
}
