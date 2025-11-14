using Business.ServiceResponder;
using Common.Models.Items;
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
        
        public async Task<ItemDto> CreateItemAsync(ItemDto ItemDto, int userStorageLocationId, int stock)
        {
            return await _itemsRepository.CreateItemAsync(ItemDto, userStorageLocationId, stock);
        }

        public async Task<List<ItemDto>> GetAllItemsAsync()
        {
            return await _itemsRepository.GetAllAsync();
        }
        
        public async Task<int> DeleteItemAsync(int id)
        {
            return await _itemsRepository.DeleteItemAsync(id);
        }
    }
}
