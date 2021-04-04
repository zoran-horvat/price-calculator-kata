namespace PriceCalculator
{
    public class TotalPrice
    {
        private readonly TaxRate _taxRate;
        private readonly Price _priceBeforeTax;
        private readonly Price _priceAfterTax;

        public TotalPrice(TaxRate taxRate, Price price)
        {
            _taxRate = taxRate;
            _priceBeforeTax = price;
            _priceAfterTax = price + taxRate.GetTaxFor(price);
        }

        public override string ToString()
            => $"Product price is {_priceBeforeTax} before tax and {_priceAfterTax} after {_taxRate} tax";
    }
}