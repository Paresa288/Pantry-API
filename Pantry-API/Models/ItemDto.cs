using Persistence.Entities;

namespace Pantry_API.Models
{
    public class ItemDto
    {
        public string Name { get; set; }
        public int CategrotyId { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }
        public double Stock { get; set; }
        public string Unit { get; set; } = null!;
        public DateTime? ExpDate { get; set; }
        public string? Notes { get; set; }
        public Category Category { get; set; } = null!;
        public StorageLocation Location { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
