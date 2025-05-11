using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Domain.Seeders
{

    public class EShopSeeder : IEShopSeeder
    {
        private readonly DataContext _context;

        public EShopSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            // Seedowanie kategorii
            if (!_context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Toys" },
                    new Category { Name = "Electronics" },
                    new Category { Name = "Books" }
                };

                await _context.Categories.AddRangeAsync(categories);
                await _context.SaveChangesAsync();
            }

            // Seedowanie produktów
            if (!_context.Products.Any())
            {
                var toys = new List<Product>
                {
                    new Product { Name = "Cobi", Ean = "1234", Sku = "SKU001" },
                    new Product { Name = "Duplo", Ean = "431", Sku = "SKU002" },
                    new Product { Name = "Lego", Ean = "12212", Sku = "SKU003" }
                };

                await _context.Products.AddRangeAsync(toys);
                await _context.SaveChangesAsync();
            }
        }
    }
}
