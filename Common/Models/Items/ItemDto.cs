namespace Common.Models.Items
{ 
    public class ItemDto
    {
        public string Name { get; set; }
        public string Unit { get; set; } = null!;
        public int CategoryId { get; set; }
        public DateTime? ExpDate { get; set; }
    }
}
