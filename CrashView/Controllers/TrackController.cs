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
    public class TrackController : ControllerBase
    {
        private readonly DataContext _context;

        public TrackController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Track
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return await _context.Track.ToListAsync();
        }

        // GET: api/Track/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await _context.Track.FindAsync(id);

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }

        // PUT: api/Track/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, Track track)
        {
            if (id != track.Track_ID)
            {
                return BadRequest();
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // POST: api/Track
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track track)
        {
            _context.Track.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrack), new { id = track.Track_ID }, track);
        }

        // DELETE: api/Track/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var track = await _context.Track.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            _context.Track.Remove(track);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Any(e => e.Track_ID == id);
        }
    }
}
