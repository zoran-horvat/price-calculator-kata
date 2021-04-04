using System;

namespace PriceCalculator
{
    public class ProductName
    {
        private readonly string _value;

        public ProductName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Product name must have value");
            }

            _value = value;
        }
    }
}