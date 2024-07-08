using AutoMapper;
using CrashView.Dto.Request;
using CrashView.Dto.Response;
using CrashView.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrashController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CrashController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Crash
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrashResponseDto>>> GetCrashes()
        {
            var crashes = await _context.Crashes.ToListAsync();
            var crashDtos = _mapper.Map<IEnumerable<CrashResponseDto>>(crashes);
            return Ok(crashDtos);
        }

        // GET: api/Crash/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CrashResponseDto>> GetCrash(int id)
        {
            var crash = await _context.Crashes.FindAsync(id);

            if (crash == null)
            {
                return NotFound();
            }

            var crashDto = _mapper.Map<CrashResponseDto>(crash);
            return Ok(crashDto);
        }

        // PUT: api/Crash/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrash(int id, [FromBody] CrashRequestDto crashRequestDto)
        {
            if (id != crashRequestDto.Crash_ID)
            {
                return BadRequest();
            }

            var crash = _mapper.Map<Crash>(crashRequestDto);
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
        [HttpPost]
        public async Task<ActionResult<CrashResponseDto>> PostCrash([FromBody] CrashRequestDto crashRequestDto)
        {
            var crash = _mapper.Map<Crash>(crashRequestDto);
            _context.Crashes.Add(crash);
            await _context.SaveChangesAsync();

            var crashDto = _mapper.Map<CrashResponseDto>(crash);
            return CreatedAtAction(nameof(GetCrash), new { id = crashDto.Crash_ID }, crashDto);
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
