using Business.ServiceResponder;
using Common.Models.Items;

namespace Business.ItemsService
{
    public interface IItemsService
    {
        public Task<ServiceResponse<List<ItemDto>>> GetAllItemsAsync();

        public Task<ServiceResponse<int>> CreateItemAsync(CreateItemDto createItemDto);
    }
}
