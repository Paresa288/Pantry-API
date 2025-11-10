using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Seeds
{
    public class RolesSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Administrator with full access"
                },
                new Role
                {
                    Id = 2,
                    Name = "User",
                    Description = "Regular user with limited access"
                }
                );
        }
    }
}
