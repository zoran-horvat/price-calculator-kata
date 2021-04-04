using System;

namespace PriceCalculator
{
    public class TaxRate
    {
        public int Rate { get; }

        public TaxRate(int rate)
        {
            if (rate < 0)
            {
                throw new ArgumentException("Tax rate must be non-negative");
            }

            // Is there any upper limit to tax?
            Rate = rate;
        }

        public Price GetTaxFor(Price price)
        {
            var value = price.Value * Rate / 100;
            return new Price(value);
        }

        public override string ToString()
            => $"{Rate}%";
    }
}