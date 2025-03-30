namespace EShop.Domain.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; } = default!;
        public bool deleted { get; set; } = false;
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public Guid created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public Guid? updated_by { get; set; }
    }
}
