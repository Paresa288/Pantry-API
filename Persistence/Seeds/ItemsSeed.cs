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
                    Name = "Tomato sauce",
                    Unit = "pcs",
                    ExpDate = new DateTime(11 / 22 / 2025),
                    LocationId = 1,
                },
                new Item
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Milk",
                    Unit = "liters",
                    ExpDate = new DateTime(11 / 22 / 2025),
                    LocationId = 1,
                },
                new Item
                {
                    Id = 3,
                    CategoryId = 3,
                    Name = "Apples",
                    Unit = "kg",
                    ExpDate = new DateTime(11 / 22 / 2025),
                    LocationId = 2,
                }
                );

        }
    }
}
