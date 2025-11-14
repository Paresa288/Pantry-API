using Common.Models.StorageLocations;

namespace Business.StorageLocationsService
{
    public interface IStorageLocationsService
    {
        public Task<int> CreateStorageLocationAsync(CreateStorageLocationDto createStorageLocationDto);
        public Task<List<StorageLocationDto>> GetAllStorageLocationsAsync();
        public Task<StorageLocationDto> GetStorageLocationsByIdAsync(int id);
        public Task<int> DeleteStorageLocationAsync(int id);
    }
}
