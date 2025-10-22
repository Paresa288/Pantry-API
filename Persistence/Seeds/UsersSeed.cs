using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Seeds
{
    public class UsersSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "admin",
                    Email = "admin@example.com",
                    Password = "123456",
                    RoleId = 1,
                });
        }
    }
}
