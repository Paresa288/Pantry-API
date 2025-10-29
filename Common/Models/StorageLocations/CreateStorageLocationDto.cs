namespace Common.Models.StorageLocations
{
    public class CreateStorageLocationDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
