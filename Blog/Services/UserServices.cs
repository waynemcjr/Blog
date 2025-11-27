using Azure;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.InterfaceRepositories;

namespace Blog.API.Services
{
    public class UserServices
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
    }
}
