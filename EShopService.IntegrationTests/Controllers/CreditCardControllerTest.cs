/*
using EShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace EShopService.IntegrationTests.Controllers
{
    public class CreditCardControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public CreditCardControllerIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("4111111111111111", HttpStatusCode.OK)]
        [InlineData("123", HttpStatusCode.BadRequest)]
        [InlineData("123456789012345678901234567890", HttpStatusCode.RequestUriTooLong)]
        [InlineData("abcdefg", HttpStatusCode.BadRequest)]
        public async Task GetCardNumberValidation_ShouldReturnExpectedStatusCode(string cardNumber, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                // *** TUTAJ czyścimy bazę ***
                dbContext.Products.RemoveRange(dbContext.Products);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                await dbContext.SaveChangesAsync();
            }

            // Act
            var response = await _client.GetAsync($"/api/creditcard?cardNumber={cardNumber}");

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }
    }

}
*/