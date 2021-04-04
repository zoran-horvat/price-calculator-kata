namespace PriceCalculator
{
    public class Product
    {
        private readonly ProductName _name;
        private readonly Upc _upc;
        private readonly Price _price;

        public Product(ProductName name, Upc upc, Price price)
        {
            _name = name;
            _upc = upc;
            _price = price;
        }

        public TotalPrice Apply(TaxRate taxRate)
            => new TotalPrice(taxRate, _price);
    }
}