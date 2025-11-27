using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Services.InterfaceServices;

namespace Blog.API.Services
{
    public class RoleService : IRoleServices
    {
        private RoleRepository _roleRepository;

        public RoleService(RoleRepository rolerepository)
        {
            _roleRepository = rolerepository;
        }

        public async Task CreateRoleAsync(RoleRequestDTO role)
        {
            var newRole = new Role(role.Name, role.Name.ToLower().Replace(" ", "-"));
            await _roleRepository.CreateRoleAsync(newRole);
        }

        public async Task<RoleResponseDTO> DeleteRoleByIdAsync(int id)
        {
            return await _roleRepository.DeleteRoleByIdAsync(id);
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<RoleResponseDTO> GetOneRoleByIdAsync(int id)
        {
            return await _roleRepository.GetOneRoleByIdAsync(id);
        }

        public async Task UpdateRoleByIdAsync(Role role, int id)
        {
            await _roleRepository.UpdateRoleByIdAsync(role, id);
        }
    }
}
