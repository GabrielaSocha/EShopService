using EShop.Application;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Domain.Test
{
    public class CreditCardProviderTest
    {
        private readonly CreditCardService _service = new();

        [Fact]
        public void ValidateCardNumber_ShouldThrowTooShortException()
        {
            Assert.Throws<CardNumberTooShortException>(() => _service.ValidateCardNumber("12345"));
        }

        [Fact]
        public void ValidateCardNumber_ShouldThrowTooLongException()
        {
            Assert.Throws<CardNumberTooLongException>(() => _service.ValidateCardNumber("123456789012345678901"));
        }

        [Fact]
        public void ValidateCardNumber_ShouldReturnTrueForValidCard()
        {
            Assert.True(_service.ValidateCardNumber("4123456789012"));  // Visa
            Assert.True(_service.ValidateCardNumber("5123456789012345")); // MasterCard
            Assert.True(_service.ValidateCardNumber("378523393817437")); // American Express
        }

        [Fact]
        public void ValidateCardNumber_ShouldReturnFalseForInvalidCard()
        {
            Assert.False(_service.ValidateCardNumber("9999999999999999"));
        }

        [Fact]
        public void GetCardType_ShouldDetectVisa()
        {
            Assert.Equal("Visa", _service.GetCardType("4123456789012"));
        }

        [Fact]
        public void GetCardType_ShouldDetectMasterCard()
        {
            Assert.Equal("MasterCard", _service.GetCardType("5123456789012345"));
        }

        [Fact]
        public void GetCardType_ShouldDetectAmericanExpress()
        {
            Assert.Equal("American Express", _service.GetCardType("378523393817437"));
        }

        [Fact]
        public void GetCardType_ShouldThrowCardNumberInvalidException()
        {
            Assert.Throws<CardNumberInvalidException>(() => _service.GetCardType("9999999999999999"));
        }

        [Fact]
        public void GetCardType_ShouldHandleFormattedCardNumber()
        {
            Assert.Equal("Visa", _service.GetCardType("4123-4567-8901-2345"));
            Assert.Equal("MasterCard", _service.GetCardType("5123 4567 8901 2345"));
        }

        [Fact]
        public void ValidateCardNumber_ShouldReturnFalseForInvalidCharacters()
        {
            Assert.False(_service.ValidateCardNumber("1234abcd56783"));
        }
    }
}
