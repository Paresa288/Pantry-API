using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    public class Item
    {
        public int Id { get; set; }
        
        [MaxLength(100), Required]
        public string Name { get; set; } = null!;
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public double Stock { get; set; }

        [MaxLength(20)]
        public string Unit { get; set; } = null!;
        public DateTime? ExpDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }

        public Category Category { get; set; } = null!;
        public StorageLocation Location { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
