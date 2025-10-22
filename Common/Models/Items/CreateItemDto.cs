namespace Common.Models.Items
{
    public class CreateItemDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Unit { get; set; } = null!;
    }
}
