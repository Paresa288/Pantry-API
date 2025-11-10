using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Seeds
{
    public class CategoriesSeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Lácteos",
                    Description = "Productos derivados de la leche."
                },
                new Category
                {
                    Id = 2,
                    Name = "Conservas",
                    Description = "Alimentos enlatados o en frascos."
                },
                new Category
                {
                    Id = 3,
                    Name = "Frutas y Verduras",
                    Description = "Productos frescos como frutas y verduras."
                }
                );
        }
    }
}
