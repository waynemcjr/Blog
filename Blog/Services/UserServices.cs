using Azure;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.InterfaceRepositories;
using Blog.API.Services.InterfaceServices;

namespace Blog.API.Services
{
    public class UserServices : IUserService
    {
        private UserRepository _userRepository;

        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(UserRequestDTO user)
        {
            var newUser = new User(user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Name.ToLower().Replace(" ", "-"));
            await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<UserResponseDTO> DeleteUserByIdAsync(int id)
        {
            return await _userRepository.DeleteUserByIdAsync(id);
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<UserResponseDTO> GetOneUserByIdAsync(int id)
        {
            return await _userRepository.GetOneUserByIdAsync(id);
        }

        public async Task UpdateUserByIdAsync(User user, int id)
        {
            await _userRepository.UpdateUserByIdAsync(user, id);
        }
    }
}
