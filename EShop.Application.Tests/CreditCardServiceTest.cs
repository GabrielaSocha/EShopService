namespace EShop.Application.Tests;
using EShop.Application;
using System.Text.RegularExpressions;

public class CreditCardServiceTest
    {
    [Fact]
    public void ValidateCard_ShouldReturnFalse_WhenTooShort()
    {
        string cardNumber = "123456789012"; // 12 cyfr - za krótka
        bool result = ValidateCard(cardNumber);
        Assert.False(result);
    }

    [Fact]
    public void ValidateCard_ShouldReturnTrue_WhenValidLength()
    {
        string cardNumber = "1234567890123"; // 13 cyfr - poprawna
        bool result = ValidateCardLength(cardNumber);
        Assert.True(result);
    }

    [Fact]
    public void ValidateCard_ShouldReturnFalse_WhenTooLong()
    {
        string cardNumber = "12345678901234567890"; // 20 cyfr - za d³uga
        bool result = ValidateCardLength(cardNumber);
        Assert.False(result);
    }

    [Fact]
    public void ValidateCard_ShouldAllowSpaces()
    {
        string cardNumber = "1234 5678 9012 3456";
        bool result = ValidateCardFormat(cardNumber);
        Assert.True(result);
    }

    [Fact]
    public void ValidateCard_ShouldAllowDashes()
    {
        string cardNumber = "1234-5678-9012-3456";
        bool result = ValidateCardFormat(cardNumber);
        Assert.True(result);
    }

    [Fact]
    public void ValidateCard_ShouldAllowMixedSeparators()
    {
        string cardNumber = "12-34 56-78 90-12 34-56";
        bool result = ValidateCardFormat(cardNumber);
        Assert.True(result);
    }


    
}