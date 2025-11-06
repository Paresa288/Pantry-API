using Common.Models.Items_Users_StorageLocations;

namespace Persistence.Repository.Items_Users_StorageLocationsRepository
{
    public class Items_Users_StorageLocationsRepository : IItems_Users_StorageLocationsRepository
    {
        private readonly PantryDbContext _context;

        public Items_Users_StorageLocationsRepository(PantryDbContext context)
        {
            _context = context;
        }

        public Task<List<Items_Users_StorageLocationsDto>> GetItemsInUserLocationAsync(int itemId, int userId, int storageLocationId)
        {
            throw new NotImplementedException();
        }
    }
}
