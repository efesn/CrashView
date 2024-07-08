using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrashView.Entities;
using CrashView.Dto.Request;
using CrashView.Dto.Response;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RaceController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Race
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceResponseDto>>> GetRaces()
        {
            var races = await _context.Races.Include(r => r.Season).Include(r => r.Track).ToListAsync();
            var raceDtos = _mapper.Map<IEnumerable<RaceResponseDto>>(races);
            return Ok(raceDtos);
        }

        // GET: api/Race/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceResponseDto>> GetRace(int id)
        {
            var race = await _context.Races.Include(r => r.Season).Include(r => r.Track).FirstOrDefaultAsync(r => r.Race_ID == id);

            if (race == null)
            {
                return NotFound();
            }

            var raceDto = _mapper.Map<RaceResponseDto>(race);
            return Ok(raceDto);
        }

        // PUT: api/Race/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(int id, [FromBody] RaceResponseDto raceRequestDto)
        {
            if (id != raceRequestDto.Race_ID)
            {
                return BadRequest();
            }

            var race = _mapper.Map<Race>(raceRequestDto);
            race.Race_ID = id; 

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
        public async Task<ActionResult<RaceResponseDto>> PostRace([FromBody] RaceRequestDto raceRequestDto)
        {
            var race = _mapper.Map<Race>(raceRequestDto);
            _context.Races.Add(race);
            await _context.SaveChangesAsync();

            var raceDto = _mapper.Map<RaceResponseDto>(race);
            return CreatedAtAction(nameof(GetRace), new { id = raceDto.Race_ID }, raceDto);
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
