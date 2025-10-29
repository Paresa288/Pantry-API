using Business.ServiceResponder;
using Common.Models.Categories;

namespace Business.CategoriesService
{
    public interface ICategoriesService
    {
        public Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync();
        public Task<ServiceResponse<CategoryDto>> GetCategoryByIdAsync(int id);
        public Task<ServiceResponse<int>> CreateCategoryAsync(CategoryDto CategoryDto);
        public Task<ServiceResponse<int>> DeleteCategoryAsync(int id);

    }
}
