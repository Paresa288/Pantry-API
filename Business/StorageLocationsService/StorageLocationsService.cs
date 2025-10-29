using Business.ServiceResponder;
using Common.Models.StorageLocations;
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
        
        public async Task<ServiceResponse<int>> CreateStorageLocationAsync(CreateStorageLocationDto createStorageLocationDto)
        {
            try
            {
                var storageLocationId = await _storageLocationsRepository.CreateStorageLocationAsync(createStorageLocationDto);
                return ServiceResponse<int>._Success(storageLocationId, 201);
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Fail($"Error creating storage location: {ex.Message}", 500);
            }

        }

        public async Task<ServiceResponse<int>> DeleteStorageLocationAsync(int id)
        {
            try
            {
                await _storageLocationsRepository.DeleteStorageLocationAsync(id);
                return ServiceResponse<int>._Success(id, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Fail($"Error deleting storage location: {ex.Message}", 500);

            }
        }

        public async Task<ServiceResponse<List<StorageLocationDto>>> GetAllStorageLocationsAsync()
        {
            try
            {
                var storageLocations = await _storageLocationsRepository.GetAllAsync();
                return ServiceResponse<List<StorageLocationDto>>._Success(storageLocations, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<StorageLocationDto>>.Fail($"Error retrieving storage locations: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<StorageLocationDto>> GetStorageLocationsByIdAsync(int id)
        {
            try { 
                var storageLocation =  await _storageLocationsRepository.GetByIdAsync(id);
                return ServiceResponse<StorageLocationDto>._Success(storageLocation, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<StorageLocationDto>.Fail($"Error retrieving storage location: {ex.Message}", 500);
            }
        }
    }
}
