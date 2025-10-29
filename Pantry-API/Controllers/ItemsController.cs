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
            return StatusCode(items.StatusCode, items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDto createItemDto)
        {
            var result = await _itemsService.CreateItemAsync(createItemDto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
