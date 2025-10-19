using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities.StorageLocations
{
    public class StorageLocation
    {
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
