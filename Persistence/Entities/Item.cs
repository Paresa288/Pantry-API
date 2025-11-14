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

        /// <summary>
        /// Gets or sets the measuring unit of the item.
        /// </summary>
        [MaxLength(20), Required]
        public string Unit { get; set; } = null!;

        /// <summary>
        /// Gets or sets the expiration date of the item.
        /// </summary>
        public DateTime? ExpDate { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the item.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the category identifier of the item.
        /// </summary>
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 
        /// gets or sets the category associated with the item.
        /// </summary>
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Gets or sets the location identifier for the item.
        /// </summary>
        [ForeignKey("StorageLocation")]
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the location associated with the item.
        /// </summary>
        public StorageLocation StorageLocation { get; set; } = null!;
    }
}
