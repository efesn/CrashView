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
    public class CrashController : ControllerBase
    {
        private readonly DataContext _context;

        public CrashController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Crash
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crash>>> GetCrashes()
        {
            return await _context.Crashes.ToListAsync();
        }

        // GET: api/Crash/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crash>> GetCrash(int id)
        {
            var crash = await _context.Crashes.FindAsync(id);

            if (crash == null)
            {
                return NotFound();
            }

            return crash;
        }

        // PUT: api/Crash/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrash(int id, [FromBody] Crash crash)
        {
            if (id != crash.Crash_ID)
            {
                return BadRequest();
            }

            _context.Entry(crash).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrashExists(id))
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

        // POST: api/Crash
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        public async Task<ActionResult<Crash>> PostCrash([FromBody] Crash crash)
        {
            _context.Crashes.Add(crash);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCrash), new { id = crash.Crash_ID }, crash);
        }

        // DELETE: api/Crash/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrash(int id)
        {
            var crash = await _context.Crashes.FindAsync(id);
            if (crash == null)
            {
                return NotFound();
            }

            _context.Crashes.Remove(crash);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrashExists(int id)
        {
            return _context.Crashes.Any(e => e.Crash_ID == id);
        }
    }
}
