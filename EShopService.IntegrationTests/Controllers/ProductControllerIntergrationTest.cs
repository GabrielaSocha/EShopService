using EShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using EShop.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace EShopService.IntegrationTests.Controllers
{
    public class ProductControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private WebApplicationFactory<Program> _factory;

        public ProductControllerIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // pobranie dotychczasowej konfiguracji bazy danych
                        var dbContextOptions = services
                            .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DataContext>));

                        //// usuniêcie dotychczasowej konfiguracji bazy danych
                        services.Remove(dbContextOptions);

                        // Stworzenie nowej bazy danych
                        services
                            .AddDbContext<DataContext>(options => options.UseInMemoryDatabase("MyDBForTest"));

                    });
                });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsAllProducts()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                // Pobranie kontekstu bazy danych
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);

                // Stworzenie obiektu
                dbContext.Products.AddRange(
                    new Product { Name = "Product1", Ean = "111", Sku = "SKU01" },
                    new Product { Name = "Product2", Ean = "112", Sku = "SKU02" }
                );
                // Zapisanie obiektu
                await dbContext.SaveChangesAsync();
            }

            // Act
            var response = await _client.GetAsync("/api/product");

            // Assert
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.Equal(2, products?.Count);
        }
        /*
        [Fact]
        public async Task Post_AddThousandsProductsAsync_ExceptedThousandsProducts()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                await dbContext.SaveChangesAsync();

                // Act
                var stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < 10000; i++)
                {
                    var product = new Product
                    {
                        Name = $"Product_{i}",
                        Sku = $"SKU_{i}",
                        Ean = $"EAN_{i}"
                    };

                    await dbContext.Products.AddAsync(product);
                    await dbContext.SaveChangesAsync(); // zapisujemy za ka¿dym razem
                }

                stopwatch.Stop();
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                // Assert
                var allProducts = await dbContext.Products.ToListAsync();
                Assert.Equal(10000, allProducts.Count);

                Console.WriteLine($"Czas wykonania (ASYNC zapis w pêtli): {elapsedMilliseconds} ms");
            }
        }
        [Fact]
        public async Task Post_AddThousandsProducts_ExceptedThousandsProducts()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                await dbContext.SaveChangesAsync();

                // Act
                var stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < 10000; i++)
                {
                    var product = new Product
                    {
                        Name = $"Product_{i}",
                        Sku = $"SKU_{i}",
                        Ean = $"EAN_{i}"
                    };

                    dbContext.Products.Add(product);
                    dbContext.SaveChanges(); // zapis synchronizacyjny po ka¿dym produkcie
                }

                stopwatch.Stop();
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                // Assert
                var allProducts = await dbContext.Products.ToListAsync();
                Assert.Equal(10000, allProducts.Count);

                Console.WriteLine($"Czas wykonania (SYNC zapis w pêtli): {elapsedMilliseconds} ms");
            }
        }
        */
        [Fact]
        public async Task Add_AddProduct_ExceptedOneProduct()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                await dbContext.SaveChangesAsync();
            }

            var product = new Product
            {
                Name = "TestProduct",
                Sku = "TESTSKU",
                Ean = "TESTEAN"
            };

            // Act
            var response = await _client.PatchAsJsonAsync("/api/product", product);

            // Assert
            response.EnsureSuccessStatusCode();
            var createdProduct = await response.Content.ReadFromJsonAsync<Product>();
            Assert.NotNull(createdProduct);
            Assert.Equal("TestProduct", createdProduct?.Name);

            // dodatkowo sprawdŸ ile jest produktów w bazie
            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                var productsInDb = await dbContext.Products.ToListAsync();
                Assert.Single(productsInDb);
            }
        }


    }
}