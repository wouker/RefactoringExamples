namespace StartingPoint.Price
{
    class ChildrenPrice : Price
    {
        public override PriceCodes PriceCode => PriceCodes.Childrens;

        public override double Calculate(int daysRented)
        {
            var thisAmount = 1.5;
            if (daysRented > 3)
                thisAmount = (daysRented - 3) * 1.5;
            return thisAmount;
        }
    }
}
