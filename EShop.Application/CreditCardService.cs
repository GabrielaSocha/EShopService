using System.Text.RegularExpressions;
using EShop.Domain.Enums;
using EShop.Domain.Exceptions;

namespace EShop.Application
{
    public class CreditCardService
    {
        public CreditCardProvider? ValidateCard(string cardNumber)
        {
            string cleanedNumber = Regex.Replace(cardNumber, "[^0-9]", "");

            if (cleanedNumber.Length < 13)
                throw new CardNumberTooShortException();
            if (cleanedNumber.Length > 19)
                throw new CardNumberTooLongException();
            if (!Regex.IsMatch(cleanedNumber, "^[0-9]+$"))
                throw new CardNumberInvalidException();

            return GetCardType(cleanedNumber);
        }

        private CreditCardProvider GetCardType(string number)
        {
            if (Regex.IsMatch(number, "^4[0-9]{12}(?:[0-9]{3})?$")) return CreditCardProvider.Visa;
            if (Regex.IsMatch(number, "^(?:5[1-5][0-9]{14}|2[2-7][0-9]{14})$")) return CreditCardProvider.MasterCard;
            if (Regex.IsMatch(number, "^3[47][0-9]{13}$")) return CreditCardProvider.AmericanExpress;
            if (Regex.IsMatch(number, "^6(?:011|5[0-9]{2})[0-9]{12}$")) return CreditCardProvider.Discover;
            if (Regex.IsMatch(number, "^(?:352[89]|35[3-8][0-9])[0-9]{12}$")) return CreditCardProvider.JCB;
            if (Regex.IsMatch(number, "^3(?:0[0-5]|[68][0-9])[0-9]{11}$")) return CreditCardProvider.DinersClub;
            if (Regex.IsMatch(number, "^(?:50|5[6-9]|6[0-9])[0-9]{10,17}$")) return CreditCardProvider.Maestro;
            return CreditCardProvider.Unknown;
        }
    }
}