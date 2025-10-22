using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    public class Users_StorageLocations
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        
        [ForeignKey("StorageLocation")]
        public int StorageLocationId { get; set; }
        public StorageLocation StorageLocation { get; set; } = null!;
    }
}
