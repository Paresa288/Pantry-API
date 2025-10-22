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
            return await _context.Items.Select(i => new ItemDto{}).ToListAsync();
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

        public async Task<int> CreateItemAsync(CreateItemDto createItemDto)
        {
            var item = _context.Items.Add(new Item 
            {
                Name = createItemDto.Name,
                Unit = createItemDto.Unit,
                CategoryId = createItemDto.CategoryId
            });
            await _context.SaveChangesAsync();
            return item.Entity.Id;
        }
    }
}
