using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrashView.Entities;
using CrashView.Dto.Request;
using AutoMapper;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceResultController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RaceResultController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RaceResult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceResultDto>>> GetRaceResults()
        {
            var raceResults = await _context.RaceResults.ToListAsync();
            var raceResultDtos = _mapper.Map<List<RaceResultDto>>(raceResults);
            return Ok(raceResultDtos);
        }

        // GET: api/RaceResult/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceResultDto>> GetRaceResult(int id)
        {
            var raceResult = await _context.RaceResults.FindAsync(id);

            if (raceResult == null)
            {
                return NotFound();
            }

            var raceResultDto = _mapper.Map<RaceResultDto>(raceResult);
            return Ok(raceResultDto);
        }

        // PUT: api/RaceResult/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceResult(int id, [FromBody] RaceResultDto raceResultDto)
        {
            if (id != raceResultDto.RaceResult_ID)
            {
                return BadRequest();
            }

            var raceResult = _mapper.Map<RaceResult>(raceResultDto);
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
        public async Task<ActionResult<RaceResultDto>> PostRaceResult(RaceResultDto raceResultDto)
        {
            var raceResult = _mapper.Map<RaceResult>(raceResultDto);
            _context.RaceResults.Add(raceResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRaceResult), new { id = raceResult.RaceResult_ID }, _mapper.Map<RaceResultDto>(raceResult));
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
