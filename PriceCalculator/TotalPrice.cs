namespace PriceCalculator
{
    public class TotalPrice
    {
        public TaxRate TaxRate { get; }
        public Price PriceBeforeTax { get; }
        public Price PriceAfterTax { get; }

        public TotalPrice(TaxRate taxRate, Price price)
        {
            TaxRate = taxRate;
            PriceBeforeTax = price;
            PriceAfterTax = price + taxRate.GetTaxFor(price);
        }
    }
}