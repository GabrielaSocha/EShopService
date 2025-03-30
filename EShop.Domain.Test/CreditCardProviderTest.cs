using EShop.Application;
using EShop.Domain.Exceptions;
using EShop.Domain.Enums;

namespace EShop.Domain.Test;

public class CreditCardProviderTest
{
    private readonly CreditCardService _service = new();

    [Fact]
    public void ValidateCard_ShouldThrowTooShortException()
    {
        Assert.Throws<CardNumberTooShortException>(() => _service.ValidateCard("12345"));
    }

    [Fact]
    public void ValidateCard_ShouldThrowTooLongException()
    {
        Assert.Throws<CardNumberTooLongException>(() => _service.ValidateCard("123456789012345678901"));
    }

    [Fact]
    public void ValidateCard_ShouldDetectVisa()
    {
        Assert.Equal(CreditCardProvider.Visa, _service.ValidateCard("4123456789012"));
    }

    [Fact]
    public void ValidateCard_ShouldDetectMasterCard()
    {
        Assert.Equal(CreditCardProvider.MasterCard, _service.ValidateCard("5123456789012345"));
    }

    [Fact]
    public void ValidateCard_ShouldDetectAmericanExpress()
    {
        Assert.Equal(CreditCardProvider.AmericanExpress, _service.ValidateCard("378523393817437"));
    }

    [Fact]
    public void ValidateCard_ShouldThrowCardNumberInvalidException()
    {
        Assert.Throws<CardNumberInvalidException>(() => _service.ValidateCard("9999999999999999"));
    }

    [Fact]
    public void ValidateCard_ShouldHandleFormattedCardNumber()
    {
        Assert.Equal(CreditCardProvider.Visa, _service.ValidateCard("4123-4567-8901-2345"));
        Assert.Equal(CreditCardProvider.MasterCard, _service.ValidateCard("5123 4567 8901 2345"));
    }

    [Fact]
    public void ValidateCard_ShouldThrowInvalidCharacterException()
    {
        Assert.Throws<CardNumberInvalidException>(() => _service.ValidateCard("1234abcd56783"));
    }
}
