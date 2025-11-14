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
            if (results == null || !results.Any())
            {
                return StatusCode(204, results); // No Content
            }
            else
            {
                return StatusCode(200, results); // OK
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var result = await _iCategoriesService.GetCategoryByIdAsync(id);
            if (result == null)
            {
                return StatusCode(404, $"Category with Id {id} not found."); // Not Found
            }
            else
            {
                return StatusCode(200, result); // OK
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            var result = await _iCategoriesService.CreateCategoryAsync(categoryDto);
            if (result == null)
            {
                return StatusCode(400, "Failed to create category."); // Bad Request
            }
            else
            {
                return StatusCode(201, result); // Created
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var result = await _iCategoriesService.DeleteCategoryAsync(id);
            if (result == 0)
            {
                return StatusCode(404, $"Category with Id {id} not found."); // Not Found
            }
            else
            {
                return StatusCode(204); // No Content
            }
        }
    }
}


