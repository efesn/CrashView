using Microsoft.AspNetCore.Mvc;
using CrashView.Entities;
using CrashView.Data.Repositories;
using CrashView.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IGenericRepository<Team> _teamRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeamController(IGenericRepository<Team> teamRepository, IUnitOfWork unitOfWork)
        {
            _teamRepository = teamRepository;
            _unitOfWork = unitOfWork;
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
            await _unitOfWork.CompleteAsync();
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
            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TeamExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        private async Task<bool> TeamExists(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            return team != null;
        }
    }
}
