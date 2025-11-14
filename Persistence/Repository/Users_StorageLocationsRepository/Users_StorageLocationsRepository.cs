using Common.Models.UsersStorageLocations;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Repository.Users_StorageLocationsRepository
{
    public class Users_StorageLocationsRepository : IUsers_StorageLocationsRepository
    {
        private readonly PantryDbContext _context;

        public Users_StorageLocationsRepository(PantryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Users_StorageLocationsDto users_StorageLocationsDto)
        {
            var result = await _context.Users_StorageLocations.AddAsync(new Users_StorageLocations
            {
                UserId = users_StorageLocationsDto.UserId,
                StorageLocationId = users_StorageLocationsDto.StorageLocationId
            });
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<List<Users_StorageLocationsDto>> GetAll()
        {
            return await _context.Users_StorageLocations
                .Select(usl => new Users_StorageLocationsDto
                {
                    UserId = usl.UserId,
                    StorageLocationId = usl.StorageLocationId
                })
                .ToListAsync();
        }

        public async Task<Users_StorageLocationsDto?> GetById(int id)
        {
            return await _context.Users_StorageLocations
                .Where(usl => usl.Id == id)
                .Select(usl => new Users_StorageLocationsDto
                {
                    UserId = usl.UserId,
                    StorageLocationId = usl.StorageLocationId
                }).FirstOrDefaultAsync();
        }
                
        
        public async Task<int> Delete(int id)
        {
            var users_StorageLocations = await _context.Users_StorageLocations.FindAsync(id);
            if (users_StorageLocations == null)
            {
                return 0;
            }
            _context.Users_StorageLocations.Remove(users_StorageLocations);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
