namespace Common.Models.StorageLocations
{
    public class StorageLocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
