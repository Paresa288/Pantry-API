namespace Persistence.Entities
{
    public class Family
    {
        /// <summary>
        /// Gets or sets the unique identifier for the family.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the family.
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
