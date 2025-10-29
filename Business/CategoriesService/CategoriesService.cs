using Business.ServiceResponder;
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

        public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync()
        {
            try
            {
                var categories =  await _categoriesRepository.GetAllCategories();

                return ServiceResponse<List<CategoryDto>>._Success(categories, 200);

            }
            catch (Exception ex)
            {
                return ServiceResponse<List<CategoryDto>>.Fail("Categories not found", 404);
                
            }
        }
        
        public async Task<ServiceResponse<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _categoriesRepository.GetCategoryById(id);
                return  ServiceResponse<CategoryDto>._Success(category, 200);

            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.Fail("Category not found", 404);
                
            }
        }
        
        public async Task<ServiceResponse<int>> CreateCategoryAsync(CategoryDto CategoryDto)
        {   
            try
            {
                var categoryId = await _categoriesRepository.CreateCategory(CategoryDto);
                return ServiceResponse<int>._Success(categoryId, 200);
                
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Fail("Category could not be created", 500);
                
            }
        }
        
        public async Task<ServiceResponse<int>> DeleteCategoryAsync(int id)
        {
            try
            {                 
                var deletedCategoryId = await _categoriesRepository.DeleteCategory(id);
                return ServiceResponse<int>._Success(deletedCategoryId, 200);

            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Fail("Could not delete Category", 500);
                
            }
        }   
    }
}
