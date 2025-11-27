using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceServices
{
    public interface IUserService
    {
        Task CreateUserAsync(UserRequestDTO user);

        Task<List<UserResponseDTO>> GetAllUsersAsync();

        Task<UserResponseDTO> GetOneUserByIdAsync(int id);

        Task<UserResponseDTO> DeleteUserByIdAsync(int id);

        Task UpdateUserByIdAsync(User User, int id);
    }
}
