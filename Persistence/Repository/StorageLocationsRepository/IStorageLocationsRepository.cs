using Common.Models.StorageLocations;

namespace Persistence.Repository.StorageLocationsRepository
{
    public interface IStorageLocationsRepository
    {
        public Task<List<StorageLocationDto>> GetAllAsync();
        public Task<StorageLocationDto> GetByIdAsync(int id);
        public Task<int> CreateStorageLocationAsync(CreateStorageLocationDto createStorageLocationDto);
        public Task<int> DeleteStorageLocationAsync(int id);
    }
}
