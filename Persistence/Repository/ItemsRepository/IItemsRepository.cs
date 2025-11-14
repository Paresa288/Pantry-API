using Common.Models;

namespace Persistence.Repository.ItemsRepository
{
    public interface IItemsRepository
    {
        public Task<List<ItemDto>> GetAllAsync();
        public Task<ItemDto> CreateItemAsync(CreateItemDto createItemDto);
        public Task<int> DeleteItemAsync(int id);
        public Task<ItemDto?> GetByIdAsync(int id);
    }
}
