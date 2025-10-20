using System.ComponentModel.DataAnnotations;

namespace Common.Models.Users
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Name is too long")]
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; } 
    }
}
