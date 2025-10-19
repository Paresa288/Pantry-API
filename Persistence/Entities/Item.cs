using Azure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Entities.Users;
using Persistence.Entities.Categories;
using Persistence.Entities.StorageLocations;

namespace Persistence.Entities.Items
{
    public class Item
    {
        public int Id { get; set; }
        
        [MaxLength(100), Required]
        public string Name { get; set; } = null!;
        public int CategrotyId { get; set; }
        public int LocationId { get; set; }
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
