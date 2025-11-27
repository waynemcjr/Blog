using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;

namespace Blog.API.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryrepository)
        {
            _categoryRepository = categoryrepository;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task CreateCategoryAsync(CategoryRequestDTO category)
        {
            var newCategory = new Category(category.Name, category.Name.ToLower().Replace(" ", "-"));
            await _categoryRepository.CreateCategoryAsync(newCategory);
        }

        public async Task<CategoryResponseDTO> GetOneCategoryAsync(int id)
        {
            return await _categoryRepository.GetOneCategoryAsync(id);
        }

        public async Task<CategoryResponseDTO> DeleteCategoryByIdAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryByIdAsync(id);
        }

        public async Task UpdateCategoryByIdAsync(Category category, int id)
        {
            await _categoryRepository.UpdateCategoryByIdAsync(category, id);
        }
    }
}
