using Common.Models;

namespace Business.ItemsService
{
    public interface IItemsService
    {
        public Task<List<ItemDto>> GetAllItemsAsync();
        public Task<ItemDto?> GetItemByIdAsync(int id);
        public Task<ItemDto> CreateItemAsync(CreateItemDto createItemDto);
        public Task<int> DeleteItemAsync(int id);
    }
}
