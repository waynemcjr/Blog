using Azure;
using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task CreateUserAsync(User user)
        {
            var sql = @"INSERT INTO dbo.[User] (Name, Email, PasswordHash, Bio, Image, Slug) Values (@Name, @Email, @PasswordHash, @Bio, @Image, @Slug)";

            await _connection.ExecuteAsync(sql, new { user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug });
        }

        public async Task<UserResponseDTO> DeleteUserByIdAsync(int id)
        {
            var sql = @"DELETE FROM dbo.[User] WHERE id = @UsuarioId";

            return (await _connection.QueryFirstOrDefaultAsync<UserResponseDTO>(sql, new { UsuarioId = id }));
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var sql = "SELECT name, email, passwordHash, bio, image, slug FROM dbo.[User]";

            return (await _connection.QueryAsync<UserResponseDTO>(sql)).ToList();
        }

        public async Task<UserResponseDTO> GetOneUserByIdAsync(int id)
        {
            var sql = "SELECT name, email, passwordHash, bio, image, slug FROM dbo.[User] WHERE id = @UsuarioId";

            return (await _connection.QueryFirstOrDefaultAsync<UserResponseDTO>(sql, new { UsuarioId = id }));
        }

        public async Task UpdateUserByIdAsync(User user, int id)
        {
            var sql = "UPDATE dbo.[User] SET Name = @Name, Email = @Email, @PasswordHash = @PasswordHash, Bio = @Bio, Image = @Image, Slug = @Slug WHERE Id = @UserID";

            await _connection.ExecuteAsync(sql, new { user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug, UserID = id });
        }
    }
}
