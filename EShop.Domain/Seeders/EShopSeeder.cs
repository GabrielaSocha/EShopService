using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.Domain.Seeders;
public static class EShopSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Books" },
            new Category { Id = 3, Name = "Clothing" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Wireless Mouse",
                Ean = "1234567890123",
                Price = 29.99m,
                Stock = 100,
                Sku = "MOUSE123",
                CategoryId = 1,
                Deleted = false,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid()
            },
            new Product
            {
                Id = 2,
                Name = "Programming Book",
                Ean = "9876543210987",
                Price = 49.99m,
                Stock = 50,
                Sku = "BOOK456",
                CategoryId = 2,
                Deleted = false,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid()
            },
            new Product
            {
                Id = 3,
                Name = "T-Shirt",
                Ean = "3216549876543",
                Price = 19.99m,
                Stock = 200,
                Sku = "TSHIRT789",
                CategoryId = 3,
                Deleted = false,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid()
            }
        );
    }
}
