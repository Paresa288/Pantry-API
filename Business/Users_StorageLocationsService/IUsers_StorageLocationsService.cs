using Business.ServiceResponder;
using Common.Models.UsersStorageLocations;

namespace Business.Users_StorageLocationsService
{
    public interface IUsers_StorageLocationsService
    {
        public Task<ServiceResponse<List<Users_StorageLocationsDto>>> GetStorageLocationsByUserIdAsync(int userId);
        public Task<ServiceResponse<int>> AssignStorageLocationToUserAsync(int userId, int storageLocationId);
        public Task<ServiceResponse<int>> RemoveStorageLocationFromUserAsync(int userId, int storageLocationId);
    }
}
