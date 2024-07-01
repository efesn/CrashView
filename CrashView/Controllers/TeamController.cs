using Microsoft.AspNetCore.Mvc;
using CrashView.Entities;
using CrashView.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IGenericRepository<Team> _teamRepository;

        public TeamController(IGenericRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            await _teamRepository.InsertAsync(team);
            return CreatedAtAction(nameof(GetTeam), new { id = team.Team_ID }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Team_ID)
            {
                return BadRequest();
            }
            await _teamRepository.UpdateAsync(team);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
