using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Entities.Roles;

namespace Persistence.Entities.User
{
    internal class User
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string Email {  get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Role Role { get; set; }
    }
}
