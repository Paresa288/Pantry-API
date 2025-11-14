using Business.CategoriesService;
using Microsoft.AspNetCore.Mvc;
using Common.Models;

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
            return StatusCode(200, results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var result = await _iCategoriesService.GetCategoryByIdAsync(id);
            if (result == null)
            {
                return StatusCode(404, "Category Not found");
            }
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            var result = await _iCategoriesService.CreateCategoryAsync(categoryDto);
            if (result == 0)
            {
                return StatusCode(400, "Failed to create category");
            }
            return StatusCode(201, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var result = await _iCategoriesService.DeleteCategoryAsync(id);
            return StatusCode(200, result);
        }
    }
}


