using System.Text.RegularExpressions;

namespace EShop.Application;
    public class CreditCardService
    {
        public static class CardValidator
        {
            public static bool ValidateCard(string cardNumber)
            {
                cardNumber = cardNumber.Replace(" ", "").Replace("-", "");
                if (!cardNumber.All(char.IsDigit)) return false;

                int sum = 0;
                bool alternate = false;

                for (int i = cardNumber.Length - 1; i >= 0; i--)
                {
                    int digit = cardNumber[i] - '0';
                    if (alternate)
                    {
                        digit *= 2;
                        if (digit > 9) digit -= 9;
                    }
                    sum += digit;
                    alternate = !alternate;
                }
                return (sum % 10 == 0);
            }

            public static string GetCardType(string cardNumber)
            {
                cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

                if (Regex.IsMatch(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$")) return "Visa";
                if (Regex.IsMatch(cardNumber, @"^(?:5[1-5][0-9]{14}|2[2-7][0-9]{14})$")) return "MasterCard";
                if (Regex.IsMatch(cardNumber, @"^3[47][0-9]{13}$")) return "American Express";
                if (Regex.IsMatch(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$")) return "Discover";
                if (Regex.IsMatch(cardNumber, @"^(?:352[89]|35[3-8][0-9])[0-9]{12}$")) return "JCB";
                if (Regex.IsMatch(cardNumber, @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$")) return "Diners Club";
                if (Regex.IsMatch(cardNumber, @"^(?:50|5[6-9]|6[0-9])[0-9]{10,17}$")) return "Maestro";

                return "Unknown";
            }
        }
}
