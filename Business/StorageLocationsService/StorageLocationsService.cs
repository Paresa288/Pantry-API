using Common.Models;
using Persistence.Repository.StorageLocationsRepository;

namespace Business.StorageLocationsService
{
    public class StorageLocationsService : IStorageLocationsService
    {
        private readonly IStorageLocationsRepository _storageLocationsRepository;
        public StorageLocationsService(IStorageLocationsRepository storageLocationsRepository)
        {
            _storageLocationsRepository = storageLocationsRepository;
        }
        
        public async Task<int> CreateStorageLocationAsync(CreateStorageLocationDto createStorageLocationDto)
        {
                return await _storageLocationsRepository.CreateStorageLocationAsync(createStorageLocationDto);
        }

        public async Task<int> DeleteStorageLocationAsync(int id)
        {
                return await _storageLocationsRepository.DeleteStorageLocationAsync(id);
        }

        public async Task<List<StorageLocationDto>> GetAllStorageLocationsAsync()
        {
            return await _storageLocationsRepository.GetAllAsync();
        }
       
        public async Task<StorageLocationDto?> GetStorageLocationsByIdAsync(int id)
        {
            return await _storageLocationsRepository.GetByIdAsync(id);
        }
    }
}
