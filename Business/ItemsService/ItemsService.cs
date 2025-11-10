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
            var item = await _itemsRepository.CreateItemAsync(ItemDto, userStorageLocationId, stock);
            return item;
        }

        public async Task<List<ItemDto>> GetAllItemsAsync()
        {
            var items =  await _itemsRepository.GetAllAsync();
            return items;
        }
    }
}
