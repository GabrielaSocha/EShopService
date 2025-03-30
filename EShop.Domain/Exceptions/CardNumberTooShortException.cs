using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exceptions;

public class CardNumberTooShortException : Exception
{
    public CardNumberTooShortException() : base("Card number is too short (min 13 digits).") { }
    public CardNumberTooShortException(Exception innerException) : base("Card Number is too short", innerException) { }
}
