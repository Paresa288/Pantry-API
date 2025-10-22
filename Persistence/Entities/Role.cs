using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [MaxLength(50), Required]

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<User> Users { get; } = [];
    }
}
