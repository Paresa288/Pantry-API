using Common.Models.Categories;

namespace Persistence.Repository.CategoriesRepository
{
    public interface ICategoriesRepository
    {
        public Task<List<CategoryDto>> GetAllCategories();
        public Task<CategoryDto> GetCategoryById(int id);
        public Task<int> CreateCategory(CategoryDto categoryDto);
        public Task<int> DeleteCategory(int id);
    }
}
