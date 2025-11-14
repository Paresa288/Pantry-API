using Common.Models.Categories;
using Persistence.Repository.CategoriesRepository;

namespace Business.CategoriesService
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _categoriesRepository.GetAllCategories();
        }
        
        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            return await _categoriesRepository.GetCategoryById(id);
        }
        
        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto CategoryDto)
        {   
            return await _categoriesRepository.CreateCategory(CategoryDto);
        }
        
        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await _categoriesRepository.DeleteCategory(id);
        }

    }
}
