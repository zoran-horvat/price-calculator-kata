using PriceCalculator;
using Shouldly;
using Xunit;

namespace Tests
{
    public class TaxRateShould
    {
        [Theory]
        [InlineData(100, 20, 20)]
        [InlineData(50, 20, 10)]
        [InlineData(20.25, 20, 4.05)]
        [InlineData(20.25, 21, 4.25)]
        public void CalculateTaxForPrice(decimal priceValue, int taxRateValue, decimal expectedPrice)
        {
            // Arrange
            var price = new Price(priceValue);
            var taxRate = new TaxRate(taxRateValue);

            // Act
            var tax = taxRate.GetTaxFor(price);

            // Assert
            tax.Value.ShouldBe(expectedPrice);
        }
    }
}
