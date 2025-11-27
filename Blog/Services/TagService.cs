using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.InterfaceRepositories;

namespace Blog.API.Services
{
    public class TagService
    {
        private TagRepository _tagRepository;

        public TagService(TagRepository tagrepository)
        {
            _tagRepository = tagrepository;
        }

        public async Task CreateTagAsync(TagRequestDTO tag)
        {
            var newTag = new Tag(tag.Name, tag.Name.ToLower().Replace(" ", "-"));
            await _tagRepository.CreateTagAsync(newTag);
        }

        public async Task<TagResponseDTO> DeleteTagByIdAsync(int id)
        {
            return await _tagRepository.DeleteTagByIdAsync(id);
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllTagsAsync();
        }

        public async Task<TagResponseDTO> GetOneTagByIdAsync(int id)
        {
            return await _tagRepository.GetOneTagByIdAsync(id);
        }

        public async Task UpdateTagByIdAsync(Tag tag, int id)
        {
            await _tagRepository.UpdateTagByIdAsync(tag, id);
        }
    }
}
