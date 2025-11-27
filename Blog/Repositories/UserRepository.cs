using Azure;
using Blog.API.Data;
using Blog.API.Models;
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
    }
}
