using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private TagService _tagService;

        public TagController(TagService service)
        {
            _tagService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAllTags")]
        public async Task<ActionResult<List<TagResponseDTO>>> GetAllTagsAsync()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return Ok(tags);
        }

        [HttpPost("CreateTag")]
        public async Task<ActionResult> CreateTagAsync(TagRequestDTO tag)
        {
            await _tagService.CreateTagAsync(tag);
            return Created();
        }

        [HttpGet("GetOneTag/{id}")] // postman para usar: https://localhost:7122/api/Tag/GetOneTag/2
        public async Task<ActionResult<TagResponseDTO>> GetOneTagAsync(int id)
        {
            var tag = await _tagService.GetOneTagByIdAsync(id);
            return Ok(tag);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult> DeleteTagByIdAsync(int id)
        {
            var tag = await _tagService.DeleteTagByIdAsync(id);

            return Ok("Apagado!");
        }

        [HttpPut("UpdateById/{id}")] // https://localhost:7122/api/Tag/UpdateById/5
        public async Task<ActionResult> UpdateTagByIdAsync(int id, [FromBody] Tag tag)
        {
            await _tagService.UpdateTagByIdAsync(tag, id);
            return Ok();
        }
    }
}
