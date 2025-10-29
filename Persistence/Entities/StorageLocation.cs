using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    public class StorageLocation
    {
        public int Id { get; set; }

        [MaxLength(100), Required(ErrorMessage = "A Name is required")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
