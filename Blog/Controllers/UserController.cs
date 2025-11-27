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

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUserAsync(UserRequestDTO user)
        {
            await _userService.CreateUserAsync(user);
            return Created();
        }
    }
}
