using Business.StorageLocationsService;
using Common.Models;
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
            if (results.ToArray().Length == 0)
                return StatusCode(404, "There are no locations yet");
            return StatusCode(200, results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStorageLocationByIdAsync(int id)
        {
            var result = await _storageLocationsService.GetStorageLocationsByIdAsync(id);
            if (result == null)
                return StatusCode(404, "Location not found");
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStorageLocationAsync([FromBody] CreateStorageLocationDto createStorageLocationDto)
        {
            var result = await _storageLocationsService.CreateStorageLocationAsync(createStorageLocationDto);
            return StatusCode(201, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageLocationAsync(int id)
        {
            var result = await _storageLocationsService.DeleteStorageLocationAsync(id);
            return StatusCode(200, result);
        }
    }
}
