using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PantryDbContext : DbContext
    {
        public PantryDbContext(DbContextOptions<PantryDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Item> Items { get; set; } = null!;
        public DbSet<Entities.Category> Categories { get; set; } = null!;
        public DbSet<Entities.StorageLocation> StorageLocations { get; set; } = null!;
        public DbSet<Entities.User> Users { get; set; } = null!;
        public DbSet<Entities.Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure relationships and constraints if needed
            modelBuilder.Entity<Entities.Item>()
                .HasOne(i => i.Category)
                .WithMany()
                .HasForeignKey(i => i.CategrotyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Entities.Item>()
                .HasOne(i => i.Location)
                .WithMany()
                .HasForeignKey(i => i.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Entities.Item>()
                .HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Entities.User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        
    }
}
