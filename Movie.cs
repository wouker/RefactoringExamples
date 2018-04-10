namespace StartingPoint
{
    /// <summary>
	/// Movie is just a simple data class.
	/// </summary>
	public class Movie
	{
		/* Constructor */

		public Movie(string title, PriceCodes priceCode)
		{
			Title = title;
		    PriceCode = priceCode;
		}

		/* Properties */

		public PriceCodes PriceCode { get; set; }

	    public string Title { get; }
	
	}
}
