namespace StartingPoint.Price
{
    abstract class Price
    {
        public abstract PriceCodes PriceCode { get; }

        public abstract double Calculate(int daysRented);

        public virtual int CalculateFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}
