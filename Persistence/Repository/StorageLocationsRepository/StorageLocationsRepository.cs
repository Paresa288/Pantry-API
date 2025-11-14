using Common.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Repository.StorageLocationsRepository
{
    public class StorageLocationsRepository : IStorageLocationsRepository
    {
        private readonly PantryDbContext _context;

        public StorageLocationsRepository(PantryDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateStorageLocationAsync(CreateStorageLocationDto createStorageLocationDto)
        {
            var storageLocation = new StorageLocation
            {
                Name = createStorageLocationDto.Name,
                Description = createStorageLocationDto.Description,
                FamilyId = createStorageLocationDto.FamilyId
            };
            await _context.StorageLocations.AddAsync(storageLocation);
            await _context.SaveChangesAsync();
            return storageLocation.Id;
        }

        public async  Task<int> DeleteStorageLocationAsync(int id)
        {
            return await _context.StorageLocations
                .Where(sl => sl.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<StorageLocationDto>> GetAllAsync()
        {
            return await _context.StorageLocations
                .Select(sl => new StorageLocationDto
                {
                    Id = sl.Id,
                    Name = sl.Name,
                    Description = sl.Description,
                    FamilyId = sl.FamilyId
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<StorageLocationDto?> GetByIdAsync(int id)
        {
            return await _context.StorageLocations
                .Where(sl => sl.Id == id)
                .Select(sl => new StorageLocationDto
                {
                    Id = sl.Id,
                    Name = sl.Name,
                    Description = sl.Description,
                    FamilyId = sl.FamilyId
                })
                .FirstOrDefaultAsync();
        }
    }
}
