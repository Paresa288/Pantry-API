using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Seeds
{
    public class LocationsSeed : IEntityTypeConfiguration<StorageLocation>
    {
        public void Configure(EntityTypeBuilder<StorageLocation> builder)
        {
            builder.HasData(
                new StorageLocation
                {
                    Id = 1,
                    Name = "Pantry",
                    Description = "It's dark and fresh",
                    FamilyId = 1,
                },
                new StorageLocation
                {
                    Id = 2,
                    Name = "Inside Fridge",
                    Description = "It's the one inside the house",
                    FamilyId = 1,
                },
                new StorageLocation
                {
                    Id = 3,
                    Name = "Inside Freezer",
                    Description = "It's the one inside the house",
                    FamilyId = 1,
                }
                );
        }
    }
}
