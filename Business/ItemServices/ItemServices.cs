using Business.ServiceResponder;
using Common.Models.Items;
using Persistence.Repository.ItemsRepository;

namespace Business.ItemServices
{
    public class ItemServices : IItemServices
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemServices(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        public async Task<ServiceResponse<int>> CreateItemAsync(CreateItemDto createItemDto)
        {
            var item = await _itemsRepository.CreateItemAsync(createItemDto);
            return ServiceResponse<int>._Success(item, 201);
        }

        public async Task<ServiceResponse<List<ItemDto>>> GetAllItemsAsync()
        {
            var items =  await _itemsRepository.GetAllAsync();
            return ServiceResponse<List<ItemDto>>._Success(items, 200);
        }
    }
}
