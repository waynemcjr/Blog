using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleService _roleService;

        public RoleController(RoleService service)
        {
            _roleService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<List<RoleResponseDTO>>> GetAllRolesAsync()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult> CreateRoleAsync(RoleRequestDTO role)
        {
            await _roleService.CreateRoleAsync(role);
            return Created();
        }

        [HttpGet("GetOneRole/{id}")] // postman para usar: https://localhost:7122/api/Role/GetOneRole/2
        public async Task<ActionResult<RoleResponseDTO>> GetOneRoleAsync(int id)
        {
            var role = await _roleService.GetOneRoleByIdAsync(id);
            return Ok(role);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult> DeleteRoleByIdAsync(int id)
        {
            var role = await _roleService.DeleteRoleByIdAsync(id);

            return Ok("Apagado!");
        }

        [HttpPut("UpdateById/{id}")] // https://localhost:7122/api/Role/UpdateById/5
        public async Task<ActionResult> UpdateRoleByIdAsync(int id, [FromBody] Role role)
        {
            await _roleService.UpdateRoleByIdAsync(role, id);
            return Ok();
        }
    }
}
