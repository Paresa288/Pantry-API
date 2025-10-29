using Business.StorageLocationsService;
using Common.Models.StorageLocations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pantry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageLocationsController : ControllerBase
    {
        private readonly IStorageLocationsService _storageLocationsService;
        public StorageLocationsController(IStorageLocationsService storageLocationsService)
        {
            _storageLocationsService = storageLocationsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStorageLocationsAsync()
        {
            var results = await _storageLocationsService.GetAllStorageLocationsAsync();
            return StatusCode(results.StatusCode, results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStorageLocationByIdAsync(int id)
        {
            var result = await _storageLocationsService.GetStorageLocationsByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStorageLocationAsync([FromBody] CreateStorageLocationDto createStorageLocationDto)
        {
            var result = await _storageLocationsService.CreateStorageLocationAsync(createStorageLocationDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageLocationAsync(int id)
        {
            var result = await _storageLocationsService.DeleteStorageLocationAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
