using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Seeds;

namespace Persistence
{
    public class PantryDbContext : DbContext
    {
        public PantryDbContext(DbContextOptions<PantryDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<StorageLocation> StorageLocations { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
    }
}
