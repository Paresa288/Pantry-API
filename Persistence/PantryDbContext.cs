using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Reflection;

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
        public DbSet<Users_StorageLocations> Users_StorageLocations { get; set; } = null!;
        public DbSet<Items_Users_StorageLocations> Items_Users_StorageLocations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
