using Blog.API.Models;

namespace Blog.API.Repositories.InterfaceRepositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
    }
}
