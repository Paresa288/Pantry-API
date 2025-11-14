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
                ExpDate = i.ExpDate
            }).ToListAsync();
        }
        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }
        public async Task<int> DeleteItemAsync(int id)
        {
            return await _context.Items
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<ItemDto> CreateItemAsync(ItemDto ItemDto, int userStorageLocationId, int stock)
        {
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == ItemDto.CategoryId);
            if (!categoryExists)
                throw new InvalidOperationException($"CategoryId {ItemDto.CategoryId} does not exist."); 
            
            var item = new Item 
            {
                Name = ItemDto.Name,
                Unit = ItemDto.Unit,
                CategoryId = ItemDto.CategoryId,
                ExpDate = ItemDto.ExpDate,
            };
            await _context.Items.AddAsync(item);

            await _context.Items_Users_StorageLocations.AddAsync(new Items_Users_StorageLocations
            {
                Item = item,
                UserStorageLocationId = userStorageLocationId,
                Stock = stock
            });

            await _context.SaveChangesAsync();
            return new ItemDto
            {
                Name = item.Name,
                Unit = item.Unit,
                CategoryId = item.CategoryId,
                ExpDate = item.ExpDate,
            };
        }
    }
}
