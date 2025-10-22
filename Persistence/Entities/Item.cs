using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    /// <summary>
    /// Represents an inventory item with stock, unit, expiration date, and related categories and locations.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the unique identifier for the item.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        [MaxLength(100), Required]
        public string Name { get; set; } = null!;

        [MaxLength(20)]
        public string Unit { get; set; } = null!;
        public DateTime? ExpDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CategoryId { get; set; }
        public Category Categories { get; }
    }
}
