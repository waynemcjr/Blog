using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task CreateRoleAsync(Role role)
        {
            var sql = "INSERT INTO Role (Name, Slug) VALUES (@Name, @Slug)";

            await _connection.ExecuteAsync(sql, new { role.Name, role.Slug });
        }

        public async Task<RoleResponseDTO> DeleteRoleByIdAsync(int id)
        {
            var sql = "DELETE FROM Role WHERE id = @RoleId";

            return (await _connection.QueryFirstOrDefaultAsync<RoleResponseDTO>(sql, new { RoleId = id }));
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            var sql = "SELECT name, slug FROM Role";

            return (await _connection.QueryAsync<RoleResponseDTO>(sql)).ToList();
        }

        public async Task<RoleResponseDTO> GetOneRoleByIdAsync(int id)
        {
            var sql = "SELECT name, slug FROM Role WHERE id = @RoleId";

            return (await _connection.QueryFirstOrDefaultAsync<RoleResponseDTO>(sql, new { RoleId = id }));
        }

        public async Task UpdateRoleByIdAsync(Role role, int id)
        {
            var sql = "UPDATE Role SET Name = @RoleName, Slug = @RoleSlug WHERE id = @RoleId";

            await _connection.ExecuteAsync(sql, new { RoleName = role.Name, RoleSlug = role.Slug, RoleId = id });
        }
    }
}
