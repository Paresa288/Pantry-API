using Business.ServiceResponder;
using Common.Models.StorageLocations;

namespace Business.StorageLocationsService
{
    public interface IStorageLocationsService
    {
        public Task<ServiceResponse<int>> CreateStorageLocationAsync(CreateStorageLocationDto createStorageLocationDto);
        public Task<ServiceResponse<List<StorageLocationDto>>> GetAllStorageLocationsAsync();
        public Task<ServiceResponse<StorageLocationDto>> GetStorageLocationsByIdAsync(int id);
        public Task<ServiceResponse<int>> DeleteStorageLocationAsync(int id);
    }
}
