using Common.Models.UsersStorageLocations;
using Persistence.Repository.Users_StorageLocationsRepository;

namespace Business.Users_StorageLocationsService
{
    public class Users_StorageLocationsService : IUsers_StorageLocationsService
    {
        private readonly IUsers_StorageLocationsRepository _users_StorageLocationsRepository;

        public Users_StorageLocationsService(IUsers_StorageLocationsRepository user_StorageLocationRepository)
        {
            _users_StorageLocationsRepository = user_StorageLocationRepository;
        }

        public Task<int> AssignStorageLocationToUserAsync(int userId, int storageLocationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Users_StorageLocationsDto>> GetStorageLocationsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveStorageLocationFromUserAsync(int userId, int storageLocationId)
        {
            throw new NotImplementedException();
        }
    }
}
