using PriceCalculator;
using Shouldly;
using Xunit;

namespace Tests
{
    public class ProductShould
    {
        [Theory]
        [InlineData(100, 20, 120)]
        [InlineData(50, 20, 60)]
        [InlineData(20.25, 20, 24.30)]
        [InlineData(20.25, 21, 24.50)]
        public void CalculateTotalPriceUsingTax(decimal productPrice, int taxRateValue, decimal expectedTotalPrice)
        {
            // Arrange
            var product = new Product(
                new ProductName("C# for dummies"),
                new Upc(123),
                new Price(productPrice));

            var taxRate = new TaxRate(taxRateValue);
            
            // Act
            var totalPrice = product.Apply(taxRate);

            // Assert
            totalPrice.PriceBeforeTax.Value.ShouldBe(productPrice);
            totalPrice.PriceAfterTax.Value.ShouldBe(expectedTotalPrice);
            totalPrice.TaxRate.Value.ShouldBe(taxRateValue);
        }
    }
}