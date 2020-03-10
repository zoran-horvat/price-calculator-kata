using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata
{
    public class Money
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("amount", "format is not valid");
            if(string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("currency", "currency required");
            Amount = amount;
            Currency = currency;
        }
    }
}
