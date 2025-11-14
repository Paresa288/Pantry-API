using Common.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository.CategoriesRepository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly PantryDbContext _context;

        public CategoriesRepository(PantryDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await _context.Categories
                .Select(c => new CategoryDto
                {
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetCategoryById(int id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    Name = c.Name,
                    Description = c.Description
                }).FirstOrDefaultAsync();
            return category;
        }

        public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
        {
            var category = await _context.Categories.AddAsync(new Entities.Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            });
            await _context.SaveChangesAsync();
            return new CategoryDto { 
                Name = category.Entity.Name,
                Description = category.Entity.Description
            };
        }

        public async Task<int> DeleteCategory(int id)
        {
            return await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
