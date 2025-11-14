using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Seeds
{
    /// <summary>
    /// 
    /// </summary>
    public class FamiliesSeed : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.HasData(
                new Family
                {
                    Id = 1,
                    Name = "Reyes Santos"
                },
                new Family {
                    Id = 2,
                    Name = "Daza Morilla"
                }
            );
        }
    }
}
