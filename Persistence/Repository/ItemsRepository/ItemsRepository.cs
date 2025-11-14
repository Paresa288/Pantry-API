using Common.Models;
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
                Id = i.Id,
                Name = i.Name,
                CategoryId= i.CategoryId,
                Unit = i.Unit,
                ExpDate = i.ExpDate,
                LocationId = i.LocationId
            }).ToListAsync();
        }
        
        public async Task<ItemDto?> GetByIdAsync(int id)
        {
            return await _context.Items
                .Where(i => i.Id == id)
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    CategoryId= i.CategoryId,
                    Unit = i.Unit,
                    ExpDate = i.ExpDate,
                    LocationId = i.LocationId
                }).FirstOrDefaultAsync();
        }
        
        public async Task<int> DeleteItemAsync(int id)
        {
            return await _context.Items
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<ItemDto> CreateItemAsync(CreateItemDto createItemDto)
        {
            var item = new Item 
            {
                Name = createItemDto.Name,
                Unit = createItemDto.Unit,
                CategoryId = createItemDto.CategoryId,
                ExpDate = createItemDto.ExpDate,
                LocationId = createItemDto.LocationId
            };
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Unit = item.Unit,
                CategoryId = item.CategoryId,
                ExpDate = item.ExpDate,
                LocationId = item.LocationId
            };
        }
    }
}
