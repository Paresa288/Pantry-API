using Common.Models.Categories;

namespace Business.CategoriesService
{
    public interface ICategoriesService
    {
        public Task<List<CategoryDto>> GetAllCategoriesAsync();
        public Task<CategoryDto> GetCategoryByIdAsync(int id);
        public Task<int> CreateCategoryAsync(CategoryDto CategoryDto);
        public Task<int> DeleteCategoryAsync(int id);

    }
}
