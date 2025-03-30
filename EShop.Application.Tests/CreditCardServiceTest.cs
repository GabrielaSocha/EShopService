using EShop.Application;
using EShop.Domain.Enums;
using EShop.Domain.Exceptions;
using Xunit;

public class CreditCardServiceTest
{
    private readonly CreditCardService _service = new();

    [Fact]
    public void ValidateCard_ShouldReturnVisa()
    {
        Assert.Equal(CreditCardProvider.Visa, _service.ValidateCard("4123456789012"));
    }

    [Fact]
    public void ValidateCard_ShouldReturnMasterCard()
    {
        Assert.Equal(CreditCardProvider.MasterCard, _service.ValidateCard("5123456789012345"));
    }

    [Fact]
    public void ValidateCard_ShouldReturnAmericanExpress()
    {
        Assert.Equal(CreditCardProvider.AmericanExpress, _service.ValidateCard("371234567890123"));
    }

    [Fact]
    public void ValidateCard_ShouldReturnDiscover()
    {
        Assert.Equal(CreditCardProvider.Discover, _service.ValidateCard("6011123456789012"));
    }

    [Fact]
    public void ValidateCard_ShouldReturnJCB()
    {
        Assert.Equal(CreditCardProvider.JCB, _service.ValidateCard("3528123456789012"));
    }

    [Fact]
    public void ValidateCard_ShouldReturnDinersClub()
    {
        Assert.Equal(CreditCardProvider.DinersClub, _service.ValidateCard("30569309025904"));
    }

    [Fact]
    public void ValidateCard_ShouldReturnMaestro()
    {
        Assert.Equal(CreditCardProvider.Maestro, _service.ValidateCard("5018123456789012"));
    }

    [Fact]
    public void ValidateCard_ShouldThrowCardNumberInvalidException()
    {
        Assert.Throws<CardNumberInvalidException>(() => _service.ValidateCard("9999999999999999"));
    }

    // --- Nowe testy d³ugoœci karty ---
    [Fact]
    public void ValidateCard_ShouldThrowException_WhenTooShort()
    {
        Assert.Throws<CardNumberTooShortException>(() => _service.ValidateCard("123456789012")); // 12 cyfr
    }

    [Fact]
    public void ValidateCard_ShouldThrowException_WhenTooLong()
    {
        Assert.Throws<CardNumberTooLongException>(() => _service.ValidateCard("123456789012345678901")); // 21 cyfr
    }

    // --- Nowe testy formatu karty ---
    [Fact]
    public void ValidateCard_ShouldAllowSpaces()
    {
        Assert.Equal(CreditCardProvider.Visa, _service.ValidateCard("4123 4567 8901 2"));
    }

    [Fact]
    public void ValidateCard_ShouldAllowDashes()
    {
        Assert.Equal(CreditCardProvider.MasterCard, _service.ValidateCard("5123-4567-8901-2345"));
    }

    [Fact]
    public void ValidateCard_ShouldAllowMixedSeparators()
    {
        Assert.Equal(CreditCardProvider.Visa, _service.ValidateCard("41-23 45-67 89-01 2"));
    }
}
