using System.ComponentModel;

namespace EShopService.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = default!;
        public string ean { get; set; } = default!;
        public decimal price { get; set; }
        public int stock { get; set; } = 0;
        public string sku { get; set; } = default!;
        public Category category { get; set; } = new Category();
        public bool deleted { get; set; } = false;
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public Guid created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public Guid? updated_by { get; set; }

    }
}
