using System;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var book  = new Product(
                new ProductName("The Little Prince"),
                new Upc(12345),
                new Price(20.25m));

            var after20Tax = book.Apply(new TaxRate(20));
            var after21Tax = book.Apply(new TaxRate(21));

            Console.WriteLine(after20Tax.ToString());
            Console.WriteLine(after21Tax.ToString());

            Console.ReadKey();
        }
    }
}
