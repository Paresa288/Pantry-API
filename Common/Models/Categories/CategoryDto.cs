namespace Common.Models.Categories
{
    public class CategoryDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public CategoryDto(CategoryDto categoryDto)
        {
            Name = categoryDto.Name;
            Description = categoryDto.Description;
        }
    }
}
