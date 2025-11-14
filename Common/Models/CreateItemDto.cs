namespace Common.Models
{
    public class CreateItemDto
    {
        public string Name { get; set; }
        public string Unit { get; set; } = null!;
        public DateTime? ExpDate { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
    }
}
