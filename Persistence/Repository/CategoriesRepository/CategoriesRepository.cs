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

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category =  await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            return new CategoryDto
            {
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<int> CreateCategory(CategoryDto categoryDto)
        {
            var category = await _context.Categories.AddAsync(new Entities.Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            });
            await _context.SaveChangesAsync();
            return category.Entity.Id;
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return 0;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
