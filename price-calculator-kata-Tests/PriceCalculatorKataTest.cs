using NUnit.Framework;
using price_calculator_kata;
using System;

namespace price_calculator_kata_Tests
{
    public class PriceCalculatorKataTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateNewProduct_With_MissingField_ThrowsException()
        {
            // arrage

            //act

            //assert 
            Assert.Throws<ArgumentException>(() => new Product(null,"",null));
        }

        [Test]
        public void CreateNewMoney_with_MissingField_ThrowsException()
        {
            // arrage

            //act

            //assert 
            Assert.Throws<ArgumentException>(() => new Money(-1, ""));
        }

        [TestCase(24.30, 20)]
        [TestCase(24.50, 21)]
        public void ApplyTax_CreateProduct_ReturnPriceAfterTax(decimal expected, decimal percentage)
        {
            // arrage
            var product = new Product("The Little Prince", "12345", new Money(20.25m, "$"));

            //act
            Money price = product.ApplyTax(percentage);
            decimal actual = price.Amount;
           
            //assert 
            Assert.AreEqual(expected, actual);
        }
    }
}