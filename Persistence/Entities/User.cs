using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{ 
    /// <summary>
    /// Represents a user entity with authentication and authorization details.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the password for the user.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the role identifier for the user.
        /// </summary>
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role associated with the user.
        /// </summary>
        public Role Role { get; set; } = null!;
    }
}
