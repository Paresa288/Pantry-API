using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    public class Items_Users_StorageLocations
    {
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        
        [ForeignKey("Users_StorageLocation")]
        public int UserStorageLocationId { get; set; }
        public Users_StorageLocations Users_StorageLocation { get; set; } = null!;
        public int Stock { get; set; }
    }
}
