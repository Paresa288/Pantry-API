namespace Common.Models.Roles
{
    public class RoleDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public RoleDto(RoleDto role)
        {
            Name = role.Name;
            Description = role.Description;
        }
    }
}
