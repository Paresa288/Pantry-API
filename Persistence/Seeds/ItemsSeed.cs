using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Seeds
{
    public class ItemsSeed : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder) 
        {
            builder.HasData(
                new Item
                {
                    Id = 1,
                    CategoryId = 2,
                    Name = "Tomate Frito",
                    Unit = "pcs",
                    ExpDate = new DateTime(11 / 22 / 2025),
                },
                new Item
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Leche Sin Lactosa",
                    Unit = "liters",
                    ExpDate = new DateTime(11 / 22 / 2025),
                },
                new Item
                {
                    Id = 3,
                    CategoryId = 3,
                    Name = "Manzanas",
                    Unit = "kg",
                    ExpDate = new DateTime(11 / 22 / 2025),
                }
                );

        }
    }
}
