namespace Common.Models.Items
{
    public class CreateItemDto
    {
        public string Name { get; set; } = "";
        public string Unit { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
