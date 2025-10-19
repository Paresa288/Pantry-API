using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    public class Category
    {
        public int Id { get; set; }
        
        [MaxLength(100), Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
