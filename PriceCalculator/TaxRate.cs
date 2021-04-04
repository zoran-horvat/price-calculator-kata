using System;

namespace PriceCalculator
{
    public class TaxRate
    {
        public int Value { get; }

        public TaxRate(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Tax rate must be non-negative");
            }

            // Is there any upper limit to tax?
            Value = value;
        }

        public Price GetTaxFor(Price price)
        {
            var value = price.Value * Value / 100;
            return new Price(value);
        }

        public override string ToString()
            => $"{Value}%";
    }
}