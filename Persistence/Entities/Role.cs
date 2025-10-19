using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities.Roles
{
    public class Role
    {
        public int Id { get; set; }

        [MaxLength(50), Required]

        public string Name { get; set; } = null!;
        public string? Description { get; set; }

    }
}
