using System.ComponentModel.DataAnnotations;

namespace Common.Models.Users
{
    public class UserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Name is too long")]
        public string Name { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
