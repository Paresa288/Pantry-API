using System.ComponentModel.DataAnnotations;

namespace Common.Models.Users
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Name is too long")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } 
    }
}
