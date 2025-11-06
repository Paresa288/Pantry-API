using Common.Models.Items;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Repository.ItemsRepository
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly PantryDbContext _context;
        public ItemsRepository(PantryDbContext context)
        {
            _context = context;
        }
        public async Task<List<ItemDto>> GetAllAsync()
        {
            return await _context.Items.Select(i => new ItemDto{
                Name = i.Name,
                CategoryId= i.CategoryId,
                Unit = i.Unit,


            }).ToListAsync();
        }
        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }
        public async Task<int> DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if(item == null)
            {
                return 0;
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<int> CreateItemAsync(ItemDto ItemDto, int userStorageLocationId, int stock)
        {
            var item = new Item 
            {
                Name = ItemDto.Name,
                Unit = ItemDto.Unit,
                CategoryId = ItemDto.CategoryId
            };
            await _context.Items.AddAsync(item);

            await _context.Items_Users_StorageLocations.AddAsync(new Items_Users_StorageLocations
            {
                Item = item,
                UserStorageLocationId = userStorageLocationId,
                Stock = stock
            });

            await _context.SaveChangesAsync();
            return item.Id;
        }
    }
}
