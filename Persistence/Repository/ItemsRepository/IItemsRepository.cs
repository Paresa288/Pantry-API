using Common.Models.Items;

namespace Persistence.Repository.ItemsRepository
{
    public interface IItemsRepository
    {
        public Task<List<ItemDto>> GetAllAsync();
        public Task<int> CreateItemAsync(CreateItemDto createItemDto);
        public Task<int> DeleteItemAsync(int id);
    }
}
