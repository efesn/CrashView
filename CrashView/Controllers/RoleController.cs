using Microsoft.AspNetCore.Mvc;
using CrashView.Entities;
using CrashView.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IGenericRepository<Role> _roleRepository;

        public RoleController(IGenericRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleRepository.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            await _roleRepository.InsertAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id = role.Role_ID }, role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Role_ID)
            {
                return BadRequest();
            }
            await _roleRepository.UpdateAsync(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
