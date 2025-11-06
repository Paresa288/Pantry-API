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
        public async Task<ServiceResponse<int>> CreateItemAsync(ItemDto ItemDto, int userStorageLocationId, int stock)
        {
            var item = await _itemsRepository.CreateItemAsync(ItemDto, userStorageLocationId, stock);
            return ServiceResponse<int>._Success(item, 201);
        }

        public async Task<ServiceResponse<List<ItemDto>>> GetAllItemsAsync()
        {
            var items =  await _itemsRepository.GetAllAsync();
            return ServiceResponse<List<ItemDto>>._Success(items, 200);
        }
    }
}
