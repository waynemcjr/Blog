using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceServices
{
    public interface ITagServices
    {
        Task<List<TagResponseDTO>> GetAllTagsAsync();

        Task CreateTagAsync(TagRequestDTO tag);

        Task<TagResponseDTO> GetOneTagByIdAsync(int id);

        Task<TagResponseDTO> DeleteTagByIdAsync(int id);

        Task UpdateTagByIdAsync(Tag tag, int id);
    }
}
