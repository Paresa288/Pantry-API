using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PantryDbContext : DbContext
    {
        public PantryDbContext(DbContextOptions<PantryDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Entities.Item> Items { get; set; } = null!;
        public DbSet<Entities.Category> Categories { get; set; } = null!;
        public DbSet<Entities.StorageLocation> StorageLocations { get; set; } = null!;
        public DbSet<Entities.User> Users { get; set; } = null!;
        public DbSet<Entities.Role> Roles { get; set; } = null!;

    }
}
