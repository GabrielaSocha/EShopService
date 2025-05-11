
using EShop.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace EShop.Application
{
    public interface ICreditCardService
    {
        public Boolean ValidateCardNumber(string cardNumber);

        public string GetCardType(string cardNumber);
    }
}