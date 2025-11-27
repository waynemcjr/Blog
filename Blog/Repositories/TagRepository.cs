using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly SqlConnection _connection;

        public TagRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task CreateTagAsync(Tag tag)
        {
            var sql = "INSERT INTO Tag (Name, Slug) VALUES (@Name, @Slug)";

            await _connection.ExecuteAsync(sql, new { tag.Name, tag.Slug });
        }

        public async Task<TagResponseDTO> DeleteTagByIdAsync(int id)
        {
            var sql = "DELETE FROM Tag WHERE id = @TagId";

            return (await _connection.QueryFirstOrDefaultAsync<TagResponseDTO>(sql, new { TagId = id }));
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            var sql = "SELECT name, slug FROM Tag";

            return (await _connection.QueryAsync<TagResponseDTO>(sql)).ToList();
        }

        public async Task<TagResponseDTO> GetOneTagByIdAsync(int id)
        {
            var sql = "SELECT name, slug FROM Tag WHERE id = @TagId";

            return (await _connection.QueryFirstOrDefaultAsync<TagResponseDTO>(sql, new { TagId = id }));
        }

        public async Task UpdateTagByIdAsync(Tag tag, int id)
        {
            var sql = "UPDATE Tag SET Name = @TagName, Slug = @TagSlug WHERE id = @TagId";

            await _connection.ExecuteAsync(sql, new { TagName = tag.Name, TagSlug = tag.Slug, TagId = id });
        }
    }
}
