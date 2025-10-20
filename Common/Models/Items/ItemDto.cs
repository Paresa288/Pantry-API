using Common.Models.Categories;
using Common.Models.StorageLocations;
using Common.Models.Users;

namespace Common.Models.Items
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
        public CategoryDto Category { get; set; } = null!;
        public StorageLocationDto Location { get; set; } = null!;
        public UserDto User { get; set; } = null!;
    }
}
