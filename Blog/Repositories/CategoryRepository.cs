using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            var sql = "SELECT name, slug FROM Category";

            return (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();
        }

        public async Task CreateCategoryAsync(Category category)
        {
            var sql = "INSERT INTO Category (Name, Slug) VALUES (@Name, @Slug)";

            await _connection.ExecuteAsync(sql, new { category.Name, category.Slug });
        }

        public async Task<CategoryResponseDTO> GetOneCategoryAsync(int id)
        {
            var sql = "SELECT name, slug FROM Category WHERE id = @CategoryId";

            return (await _connection.QueryFirstOrDefaultAsync<CategoryResponseDTO>(sql, new { CategoryId = id }));
        }

        public async Task<CategoryResponseDTO> DeleteCategoryByIdAsync(int id)
        {
            var sql = "DELETE FROM Category WHERE id = @CategoryId";

            return (await _connection.QueryFirstOrDefaultAsync<CategoryResponseDTO>(sql, new { CategoryId = id }));
        }

        public async Task UpdateCategoryByIdAsync(Category category, int id)
        {
            var sql = "UPDATE Category SET Name = @CategoryName, Slug = @CategorySlug WHERE id = @CategoryId";

            await _connection.ExecuteAsync(sql, new { CategoryName = category.Name, CategorySlug = category.Slug, CategoryId = id });
        }
    }
}
