using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    public class User
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Role Role { get; set; } = null!;
    }
}
