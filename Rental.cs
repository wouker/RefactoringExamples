namespace StartingPoint
{
    /// <summary>
    /// Rental represents a customer renting a movie.
    /// </summary>
    public class Rental
    {

        /* Constructor */

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        /* Properties */

        public int DaysRented { get; }
        public Movie Movie { get; }

        /* Methods */

        public double CalculateAmount()
        {
            return Movie.CalculateAmount(DaysRented);
        }


        public int CalculateFrequentRenterPoints()
        {
            return Movie.CalculateFrequentRenterPoints(DaysRented);
        }
    }
}
