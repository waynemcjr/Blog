using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.InterfaceServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserServices _userService;

        public UserController(UserServices service)
        {
            _userService = service;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUserAsync(UserRequestDTO user)
        {
            await _userService.CreateUserAsync(user);
            return Created();
        }

        [HttpGet("GetOneUser/{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetOneUserAsync(int id)
        {
            var user = await _userService.GetOneUserByIdAsync(id);
            return Ok(user);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult> DeleteUserByIdAsync(int id)
        {
            await _userService.DeleteUserByIdAsync(id);

            return Ok("Apagado!");
        }

        [HttpPut("UpdateById/{id}")]
        public async Task<ActionResult> UpdateUserByIdAsync(int id, [FromBody] User user)
        {
            await _userService.UpdateUserByIdAsync(user, id);
            return Ok();
        }

        [HttpGet("GetUsersRoles")]
        public async Task<ActionResult<List<UserRolesResponseDTO>>> GetUsersRoles()
        {
            var users = await _userService.GetAllUsersRoles();
            return Ok(users);
        }

        [HttpGet("GetUserRolesByID/{id}")]
        public async Task<ActionResult<UserRolesResponseDTO>> GetUserRolesByID(int id)
        {
            var user = await _userService.GetUserRolesByID(id);
            return Ok(user);
        }
    }
}
