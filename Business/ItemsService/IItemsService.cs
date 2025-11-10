using Business.ServiceResponder;
using Common.Models.Items;

namespace Business.ItemsService
{
    public interface IItemsService
    {
        public Task<List<ItemDto>> GetAllItemsAsync();

        public Task<ItemDto> CreateItemAsync(ItemDto ItemDto, int userStorageLocationId, int stock);
    }
}
