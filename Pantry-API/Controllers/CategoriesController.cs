using Business.CategoriesService;
using Microsoft.AspNetCore.Mvc;
using Common.Models.Categories;

namespace Pantry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _iCategoriesService;

        public CategoriesController(ICategoriesService iCategoriesService)
        {
            _iCategoriesService = iCategoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var results = await _iCategoriesService.GetAllCategoriesAsync();
            return StatusCode(results.StatusCode, results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var result = await _iCategoriesService.GetCategoryByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            var result = await _iCategoriesService.CreateCategoryAsync(categoryDto);
            return StatusCode(result.StatusCode, result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var result = await _iCategoriesService.DeleteCategoryAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
