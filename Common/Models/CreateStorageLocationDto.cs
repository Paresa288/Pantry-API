namespace Common.Models
{
    public class CreateStorageLocationDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int FamilyId { get; set; }
    }
}
