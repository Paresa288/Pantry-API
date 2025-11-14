using Business.ItemsService;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pantry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;

        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemsService.GetAllItemsAsync();
            return StatusCode(200, items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDto createItemDto)
        {
            var result = await _itemsService.CreateItemAsync(createItemDto);
            return StatusCode(201, result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _itemsService.DeleteItemAsync(id);
            return StatusCode(200, result);
        }
    }
}
