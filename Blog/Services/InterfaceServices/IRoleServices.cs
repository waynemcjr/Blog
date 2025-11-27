using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceServices
{
    public interface IRoleServices
    {
        Task<List<RoleResponseDTO>> GetAllRolesAsync();

        Task CreateRoleAsync(RoleRequestDTO role);

        Task<RoleResponseDTO> GetOneRoleByIdAsync(int id);

        Task<RoleResponseDTO> DeleteRoleByIdAsync(int id);

        Task UpdateRoleByIdAsync(Role role, int id);
    }
}
