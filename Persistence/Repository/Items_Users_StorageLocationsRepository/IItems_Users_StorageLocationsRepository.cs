using Common.Models.Items_Users_StorageLocations;

namespace Persistence.Repository.Items_Users_StorageLocationsRepository
{
    public interface IItems_Users_StorageLocationsRepository
    {
        public Task<List<Items_Users_StorageLocationsDto>> GetItemsInUserLocationAsync(int itemId, int userId, int storageLocationId);
    }
}
