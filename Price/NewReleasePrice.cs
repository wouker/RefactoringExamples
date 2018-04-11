namespace StartingPoint.Price
{
    class NewReleasePrice : Price
    {
        public override PriceCodes PriceCode => PriceCodes.NewRelease;

        public override double Calculate(int daysRented)
        {
            return daysRented * 3;
        }
        
        public override int CalculateFrequentRenterPoints(int daysRented)
        {
            // Add bonus for a two-day new-release rental
            return daysRented > 1 ? 2 : 1;
        }
    }
}
