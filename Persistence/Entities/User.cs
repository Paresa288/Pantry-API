using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{ 
    public class User
    {
        public int ID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Role Role { get; set; } = null!;

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
