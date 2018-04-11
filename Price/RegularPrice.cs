namespace StartingPoint.Price
{
    class RegularPrice : Price
    {
        public override PriceCodes PriceCode => PriceCodes.Regular;

        public override double Calculate(int daysRented)
        {
            var thisAmount = 2d;
            if (daysRented > 2)
                thisAmount += (daysRented - 2) * 1.5;

            return thisAmount;
        }
    }
}
