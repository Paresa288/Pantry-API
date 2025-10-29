using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entities.Configuration
{
    public class StorageLocationsConfig : IEntityTypeConfiguration<StorageLocation>
    {
        public void Configure(EntityTypeBuilder<StorageLocation> builder)
        {
            builder.Property(sl => sl.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
