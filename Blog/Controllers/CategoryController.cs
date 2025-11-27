using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;

        public CategoryController(CategoryService service)
        {
            _categoryService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategory(CategoryRequestDTO category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return Created();
        }

        [HttpGet("GetOne/{id}")] // postman para usar: https://localhost:7122/api/Category/GetOne/2
        public async Task<ActionResult<CategoryResponseDTO>> GetOneCategoryAsync(int id)
        {
            var category = await _categoryService.GetOneCategoryAsync(id);
            return Ok(category);
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult> DeleteCategoryByIdAsync(int id)
        {
            var category = await _categoryService.DeleteCategoryByIdAsync(id);

            return Ok("Apagado!");
        }

        [HttpPut("UpdateById/{id}")] // https://localhost:7122/api/Category/UpdateById/5
        public async Task<ActionResult> UpdateCategoryByIdAsync(int id, [FromBody]Category category)
        {
            await _categoryService.UpdateCategoryByIdAsync(category, id);
            return Ok();
        }
    }
}
