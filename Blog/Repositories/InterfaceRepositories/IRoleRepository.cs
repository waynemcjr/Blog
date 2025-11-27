using System.Threading.Tasks;
using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.InterfaceRepositories
{
    public interface IRoleRepository
    {
        Task<List<RoleResponseDTO>> GetAllRolesAsync();

        Task CreateRoleAsync(Role role);

        Task<RoleResponseDTO> GetOneRoleByIdAsync(int id);

        Task<RoleResponseDTO> DeleteRoleByIdAsync(int id);

        Task UpdateRoleByIdAsync(Role role, int id);
    }
}
