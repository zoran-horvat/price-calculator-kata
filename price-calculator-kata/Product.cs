﻿using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata
{
    public class Product
    {
        public string Name { get; private set; }

        public string UPC { get; private set; }

        public Money Price { get; private set; }
        public Money Tax { get; private set; }
        public Money Discount { get; private set; }

        public Product(string name, string uPC, Money price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name", "name required");
            if (string.IsNullOrWhiteSpace(uPC))
                throw new ArgumentException("uPC", "uPC required");
            if (price == null)
                throw new ArgumentException("price", "price required");
            Name = name;
            UPC = uPC;
            Price = price;
            Tax = new Money(0, price.Currency);
            Discount = new Money(0, price.Currency);
        }

        public Money ApplyTax(decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException();
            var taxAmount = GetPercentageAmount(percentage);
            Tax = new Money(taxAmount, Price.Currency);
            return new Money(Price.Amount + taxAmount, Price.Currency);
        }

        private decimal GetPercentageAmount(decimal percentage)
        {
            return Math.Round((Price.Amount * percentage) / 100, 2);
        }

        public Money ApplyDicount(decimal percentageTax, decimal percentageDiscount)
        {
            if (percentageTax < 0 || percentageTax > 100)
                throw new ArgumentException("percentageTax not valid");
            if (percentageDiscount < 0 || percentageTax > 100)
                throw new ArgumentException("percentageDiscount not valid");
            var taxAmount = GetPercentageAmount(percentageTax);
            var disCountAmount = GetPercentageAmount(percentageDiscount);

            Discount = new Money(disCountAmount, Price.Currency);
            return new Money((Price.Amount + taxAmount) - disCountAmount, Price.Currency);
        }

        public Money ApplySpecialDiscount(decimal percentageTax, decimal percentageDiscount, decimal percentageDiscountUPCdiscount, string uPC)
        {
            if (percentageTax < 0 || percentageTax > 100)
                throw new ArgumentException("percentageTax not valid");
            if (percentageDiscount < 0 || percentageTax > 100)
                throw new ArgumentException("percentageDiscount not valid");
            if (percentageDiscountUPCdiscount < 0 || percentageDiscountUPCdiscount > 100)
                throw new ArgumentException("percentageDiscountUPCdiscount not valid");

            var taxAmount = GetPercentageAmount(percentageTax);
            var discountAmount = GetPercentageAmount(percentageDiscount);
            decimal discountUPCAmount = discountAmount;

            if (uPC.Equals(UPC))
                discountUPCAmount += GetPercentageAmount(percentageDiscountUPCdiscount);

            Discount = new Money(discountUPCAmount, Price.Currency);
            return new Money((Price.Amount + taxAmount) - discountUPCAmount, Price.Currency);
        }


        public Money ApplyPrecedenceDiscount(decimal percentageTax, decimal percentageDiscount,
            decimal percentageDiscountUPCdiscount, string uPC)
        {
            if (percentageTax < 0 || percentageTax > 100)
                throw new ArgumentException("percentageTax not valid");
            if (percentageDiscount < 0 || percentageTax > 100)
                throw new ArgumentException("percentageDiscount not valid");
            if (percentageDiscountUPCdiscount < 0 || percentageDiscountUPCdiscount > 100)
                throw new ArgumentException("percentageDiscountUPCdiscount not valid");
            
            decimal discountUPCAmount = 0;
            if (uPC.Equals(UPC))
                discountUPCAmount += GetPercentageAmount(percentageDiscountUPCdiscount);
            Price.Amount -= discountUPCAmount;
            var taxAmount = GetPercentageAmount(percentageTax);
            var discountAmount = GetPercentageAmount(percentageDiscount);

            Discount = new Money(discountAmount + discountUPCAmount, Price.Currency);
            return new Money((Price.Amount + taxAmount) - discountAmount, Price.Currency);
        }

    }
}
