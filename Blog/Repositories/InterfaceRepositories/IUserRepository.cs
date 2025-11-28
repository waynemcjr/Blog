using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.InterfaceRepositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);

        Task<List<UserResponseDTO>> GetAllUsersAsync();

        Task<UserResponseDTO> GetOneUserByIdAsync(int id);

        Task<UserResponseDTO> DeleteUserByIdAsync(int id);

        Task UpdateUserByIdAsync(User user, int id);

        Task<List<User>> GetAllUserRoles();
    }
}
