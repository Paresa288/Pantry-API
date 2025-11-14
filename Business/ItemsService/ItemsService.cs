using Common.Models;
using Persistence.Repository.ItemsRepository;

namespace Business.ItemsService
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemsService(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        
        public async Task<ItemDto> CreateItemAsync(CreateItemDto createItemDto)
        {
            return await _itemsRepository.CreateItemAsync(createItemDto);
        }

        public async Task<List<ItemDto>> GetAllItemsAsync()
        {
            return await _itemsRepository.GetAllAsync();
        }

        public async Task<int> DeleteItemAsync(int id)
        {
            return await _itemsRepository.DeleteItemAsync(id);
        }

        public async Task<ItemDto?> GetItemByIdAsync(int id)
        {
            return await _itemsRepository.GetByIdAsync(id);
        }
    }
}
