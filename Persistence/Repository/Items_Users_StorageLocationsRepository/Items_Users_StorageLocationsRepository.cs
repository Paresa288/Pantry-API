using Common.Models.Items_Users_StorageLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
