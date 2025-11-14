using Common.Models.UsersStorageLocations;

namespace Persistence.Repository.Users_StorageLocationsRepository
{
    public interface IUsers_StorageLocationsRepository
    {
        public Task<List<Users_StorageLocationsDto>> GetAll();
        public Task<Users_StorageLocationsDto?> GetById(int id);
        public Task<int> Create(Users_StorageLocationsDto users_StorageLocationsDto);
        public Task<int> Delete(int id);
    }
}
