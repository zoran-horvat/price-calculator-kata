using System;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var book = new Product(
                new ProductName("The Little Prince"),
                new Upc(12345),
                new Price(20.25m));

            var after20Tax = book.Apply(new TaxRate(20));
            var after21Tax = book.Apply(new TaxRate(21));

            PrintProductPrice(after20Tax);
            PrintProductPrice(after21Tax);

            Console.ReadKey();
        }

        private static void PrintProductPrice(TotalPrice price)
        {
            Console.WriteLine(
                $"Product price is {price.PriceBeforeTax} " +
                $"before tax and {price.PriceAfterTax} " +
                $"after {price.TaxRate} tax");
        }
    }
}
