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

        public async Task<List<User>> GetAllUserRoles()
        {
            IEnumerable<User> userRoles = new List<User>();

            var sql = "SELECT u.Id,u.Name,u.Email,u.PasswordHash,u.Bio,u.Image,u.Slug,r.Id AS Id,r.Name,r.Slug FROM [USER] u LEFT JOIN UserRole ur ON u.Id = ur.UserId LEFT JOIN [Role] r ON r.Id = ur.RoleId;";

            var userDictionary = new Dictionary<int, User>();

            var results = await _connection.QueryAsync<User, Role, User>(
                sql,
                (user, role) =>
                {

                    if (!userDictionary.TryGetValue(user.Id, out var existingUser))
                    {
                        userDictionary.Add(user.Id, user);
                        existingUser = user;
                    }

                    if (role != null)
                    {
                        existingUser.Roles.Add(role);
                    }


                    return existingUser;
                },

                 splitOn: "Id"
             );
            return userDictionary.Values.ToList();
        }

        public async Task<User> GetUserRolesByID(int id)
        {

            var sql = "SELECT u.Id,u.Name,u.Email,u.PasswordHash,u.Bio,u.Image,u.Slug,r.Id AS Id,r.Name,r.Slug FROM [USER] u LEFT JOIN UserRole ur ON u.Id = ur.UserId LEFT JOIN [Role] r ON r.Id = ur.RoleId WHERE u.Id = @UserID;";

            var userDictionary = new Dictionary<int, User>();

            await _connection.QueryAsync<User, Role, User>(
                sql,
                (user, role) =>
                {

                    if (!userDictionary.TryGetValue(user.Id, out var existingUser))
                    {
                        userDictionary.Add(user.Id, user);
                        existingUser = user;
                    }

                    if (role != null)
                    {
                        existingUser.Roles.Add(role);
                    }


                    return existingUser;
                },
                param: new { UserID = id },
                splitOn: "Id"
             );
            return userDictionary.Values.FirstOrDefault();
        }
    }
}
