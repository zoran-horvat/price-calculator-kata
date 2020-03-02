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
            Assert.Throws<ArgumentException>(() => new Product(null, "", null));
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

        [TestCase(21.26, 20, 15)]
        public void ApplyDiscount_CreateProduct_ReturnPriceAfterDiscount(decimal expected, decimal percentageTax, decimal percentageDiscount)
        {
            // arrage
            var product = new Product("The Little Prince", "12345", new Money(20.25m, "$"));

            //act
            Money price = product.ApplyDicount(percentageTax, percentageDiscount);
            decimal actual = price.Amount;

            //assert 
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ApplyTax_PercentageNotValid_ThrowsException()
        {
            // arrage
            var product = new Product("The Little Prince", "12345", new Money(20.25m, "$"));

            //act

            //assert 
            Assert.Throws<ArgumentException>(() => product.ApplyTax(-1m));
        }
        [Test]
        public void ApplyDiscount_PercentageNotValid_ThrowsException()
        {
            // arrage
            var product = new Product("The Little Prince", "12345", new Money(20.25m, "$"));

            //act

            //assert 
            var ex1 = Assert.Throws<ArgumentException>(() => product.ApplyDicount(20, -1));
            var ex2 = Assert.Throws<ArgumentException>(() => product.ApplyDicount(-1, 10));

            Assert.That(ex1.Message, Is.EqualTo("percentageDiscount not valid"));
            Assert.That(ex2.Message, Is.EqualTo("percentageTax not valid"));
        }

        [TestCase(21.26, 20, 15, 3.04)]
        [TestCase(24.30, 20, 0, 0)]
        public void PrintDiscount_CreateProduct_ReturnPriceAfterDiscount(decimal expected,
            decimal percentageTax, decimal percentageDiscount, decimal expectedDiscount)
        {
            // arrage
            var product = new Product("The Little Prince", "12345", new Money(20.25m, "$"));
            //act
            var price = product.ApplyDicount(percentageTax, percentageDiscount);
            var actual = price.Amount;
            var actualDiscount = product.Discount.Amount;
            //assert 
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedDiscount, actualDiscount);
        }

        [TestCase(20, 15, 7, "12345", 4.46, 19.84)]
        [TestCase(21, 15, 7, "789", 3.04, 21.46)]
        public void SpecialDiscount_CreateProduct_ReturnPriceAfterDiscount(
            decimal percentageTax, decimal percentageDiscount,
            decimal percentageDiscountUPCdiscount, string uPC, decimal expectedDiscount,
            decimal expectedPrice)
        {
            // arrage
            var product = new Product("The Little Prince", "12345", new Money(20.25m, "$"));
            //act
            var price = product.ApplySpecialDiscount(percentageTax, percentageDiscount,
                percentageDiscountUPCdiscount, uPC);
            var actual = price.Amount;
            var actualDiscount = product.Discount.Amount;
            //assert 
            Assert.AreEqual(expectedPrice, actual);
            Assert.AreEqual(expectedDiscount, actualDiscount);
        }

        //Precedence
        [TestCase(20, 15, 7, "12345", 4.24, 19.78)]
        public void PrecedenceDiscount_CreateProduct_ReturnPriceAfterDiscount(
            decimal percentageTax, decimal percentageDiscount,
            decimal percentageDiscountUPCdiscount, string uPC, decimal expectedDiscount,
            decimal expectedPrice)
        {
            // arrage
            var product = new Product("The Little Prince", "12345", new Money(20.25m, "$"));
            //act
            var price = product.ApplyPrecedenceDiscount(percentageTax, percentageDiscount,
                percentageDiscountUPCdiscount, uPC);
            var actual = price.Amount;
            var actualDiscount = product.Discount.Amount;
            //assert 
            Assert.AreEqual(expectedPrice, actual);
            Assert.AreEqual(expectedDiscount, actualDiscount);
        }
    }
}