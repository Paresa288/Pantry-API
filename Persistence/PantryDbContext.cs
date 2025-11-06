using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Reflection;

namespace Persistence
{
    /// <summary>
    /// Represents the Entity Framework database context for the Pantry application.
    /// Provides access to entities such as Items, Categories, StorageLocations, Users, Roles,
    /// and the relationships between them.
    /// </summary>
    public class PantryDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PantryDbContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public PantryDbContext(DbContextOptions<PantryDbContext> options) 
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the items in the pantry.
        /// </summary>
        public DbSet<Item> Items { get; set; } = null!;

        /// <summary>
        /// Gets or sets the categories for items.
        /// </summary>
        public DbSet<Category> Categories { get; set; } = null!;

        /// <summary>
        /// Gets or sets the storage locations for items.
        /// </summary>
        public DbSet<StorageLocation> StorageLocations { get; set; } = null!;

        /// <summary>
        /// Gets or sets the users of the pantry application.
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Gets or sets the roles assigned to users.
        /// </summary>
        public DbSet<Role> Roles { get; set; } = null!;

        /// <summary>
        /// Gets or sets the relationship between users and storage locations.
        /// </summary>
        public DbSet<Users_StorageLocations> Users_StorageLocations { get; set; } = null!;

        /// <summary>
        /// Gets or sets the relationship between items, users, and storage locations.
        /// </summary>
        public DbSet<Items_Users_StorageLocations> Items_Users_StorageLocations { get; set; } = null!;

        /// <summary>
        /// Configures the model for the context using the specified <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
