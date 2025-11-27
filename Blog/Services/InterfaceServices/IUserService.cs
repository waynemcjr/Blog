using Blog.API.Models;

namespace Blog.API.Services.InterfaceServices
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
    }
}
