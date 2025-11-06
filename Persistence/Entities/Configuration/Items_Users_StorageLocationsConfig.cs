using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entities.Configuration
{
    internal class Items_Users_StorageLocationsConfig : IEntityTypeConfiguration<Items_Users_StorageLocations>
    {
        public void Configure(EntityTypeBuilder<Items_Users_StorageLocations> builder)
        {
            builder.HasKey(iusl => new { iusl.ItemId, iusl.UserStorageLocationId });
        }
    }
}
