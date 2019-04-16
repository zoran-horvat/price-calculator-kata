# Price Calculator Kata

## Invitation
You are invited to implement imaginary customer’s requirements listed below, using programming language of choice and applying any coding practices you wish.

I have been using this example since 2016 in trainings and lectures. Many developers have already passed through the drill of implementing these same requirements.

## Rules of Conduct
**1. You are free to choose programming language and programming method** - This challenge is not a competition. There are no better or worse solutions per se. The goal is to evaluate expressiveness of languages and usefulness of programming paradigms. All languages and paradigms are equally welcome.

**2. Requirements should be implemented in order** - The sequence of requirements is simulating the evolution of customer's expectations over a prolonged period of time, as customer occasionally gets “bright ideas” and hands them over to developers. Implementing requirements all at once or out of order would look like real time was flowing back and forth.

**3. Application must be operative at all times** - After implementing each requirement, the application must be correct and fully operational. The newly implemented requirement, as well as all previous requirements must work. If, however, there are bugs or omissions, don’t despair – just apply a fix when you find them and carry on. That is what you would do in a day-to-day development anyway.

**4. Mark each task with the requirement label** - Include requirement label into each commit message, so that the evolution of the product can be observed later. Each requirement begins with a label in capital letters.

**5. Pretend you don’t know the requirements in advance** - Even though you can read all the requirements right away, try thinking of those beyond the one you’re currently solving as yet unknown. Don’t overengineer current solution because you have anticipated a future requirement.

## Customer’s Requirements

**1. TAX**

There is a product, defined by: Name (string), UPC (can be a plain number) and a price.

Company is only doing business in US dollars. Money is calculated at two decimals precision (e.g. $12.34).

There is a flat-rate tax (currently 20%) added to all products’ prices. Tax is mandatory and equal for all products.

Customer wants to be able to specify tax percentage.

Write code which displays base price and price with tax for a product.

**Definition of done:**

Sample product: Book with name = “The Little Prince”, UPC=12345, price=$20.25.

Product price reported as $20.25 before tax and $24.30 after 20% tax.

Product price reported as $20.25 before tax and $24.50 after 21% tax.

**2. DISCOUNT**

Customer chooses to apply a relative discount to all products.

Discount is specified as a percentage relative to price. Tax is always applied to a price before it was deduced, i.e. discount doesn’t reduce tax amount (see example below).

Customer requires discount percentage to be configurable.

Enhance code so that it can apply discount and tax to the product’s price.

**Definition of done:**

Sample product: Book with name = “The Little Prince”, UPC=12345, price=$20.25.

Tax=20%, discount=15%

Tax amount = $4.05; Discount amount = $3.04

Price before = $20.25, price after = $21.26

**3. REPORT-DISCOUNT**

When a discount is applied, print out (or display by any convenient means) a message which reports the discounted amount.

**Definition of done:**

Sample product: Title = “The Little Prince”, UPC=12345, price=$20.25.

Tax = 20%, discount = 15% - Program displays $3.04 amount which was deduced

Tax = 20%, no discount - Program doesn't display any deduced amount

(more to come)

