using Common.Models.UsersStorageLocations;

namespace Business.Users_StorageLocationsService
{
    public interface IUsers_StorageLocationsService
    {
        public Task<List<Users_StorageLocationsDto>> GetStorageLocationsByUserIdAsync(int userId);
        public Task<int> AssignStorageLocationToUserAsync(int userId, int storageLocationId);
        public Task<int> RemoveStorageLocationFromUserAsync(int userId, int storageLocationId);
    }
}
