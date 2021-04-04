using System;

namespace PriceCalculator
{
    public class Price
    {
        public decimal Value { get; }

        public Price(decimal value)
        {
            var roundedValue = Math.Round(value, 2, MidpointRounding.ToEven);

            // verify the rounded value instead of original value here
            if (roundedValue < 0)
            {
                throw new ArgumentException("Price must be non-positive");
            }

            Value = roundedValue;
        }

        public override string ToString()
            => $"${Value}";

        public static Price operator +(Price a, Price b) 
            => new Price(a.Value + b.Value);
    }
}