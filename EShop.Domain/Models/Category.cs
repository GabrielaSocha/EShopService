namespace EShop.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool Deleted { get; set; } = false;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public Guid Created_by { get; set; }
        public DateTime? Updated_at { get; set; }
        public Guid? Updated_by { get; set; }
    }
}
