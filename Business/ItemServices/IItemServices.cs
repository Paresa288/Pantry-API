using Business.ServiceResponder;
using Common.Models.Items;

namespace Business.ItemServices
{
    public interface IItemServices
    {
        public Task<ServiceResponse<List<ItemDto>>> GetAllItemsAsync();

        public Task<ServiceResponse<int>> CreateItemAsync(CreateItemDto createItemDto);
    }
}
