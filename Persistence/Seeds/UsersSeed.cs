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
                    Name = "Pablo",
                    Email = "pablo@pablo.com",
                    Password = "123456",
                    RoleId = 1,
                    FamilyId = 1,
                },
                new User
                {
                    Id = 2,
                    Name = "Javi",
                    Email = "javi@javi.com",
                    Password = "123456",
                    RoleId = 2,
                    FamilyId = 2,
                }
            );
        }
    }
}
