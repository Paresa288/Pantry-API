using Business.ItemsService;
using Common.Models.Items;
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
        public async Task<IActionResult> CreateItem([FromBody] ItemDto ItemDto, int userStorageLocationId, int stock)
        {
            var result = await _itemsService.CreateItemAsync(ItemDto, userStorageLocationId, stock);
            return StatusCode(201, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _itemsService.DeleteItemAsync(id);
            return StatusCode(204, result); 
        }
    }
}
