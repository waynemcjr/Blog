using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.InterfaceRepositories
{
    public interface ITagRepository
    {
        Task<List<TagResponseDTO>> GetAllTagsAsync();

        Task CreateTagAsync(Tag tag);

        Task<TagResponseDTO> GetOneTagByIdAsync(int id);

        Task<TagResponseDTO> DeleteTagByIdAsync(int id);

        Task UpdateTagByIdAsync(Tag tag, int id);
    }
}
