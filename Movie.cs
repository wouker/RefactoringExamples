using System;
using StartingPoint.Price;

namespace StartingPoint
{
    /// <summary>
	/// Movie is just a simple data class.
	/// </summary>
	public class Movie
	{
		/* Properties */
	    private Price.Price _price;

	    public PriceCodes PriceCode
	    {
	        get => _price.PriceCode;
	        set
	        {
	            switch (value)
	            {
	                case PriceCodes.Regular:
	                    _price = new RegularPrice();
	                    break;
	                case PriceCodes.NewRelease:
	                    _price = new NewReleasePrice();
	                    break;
	                case PriceCodes.Childrens:
	                    _price = new ChildrenPrice();
	                    break;
	                default:
	                    throw new ArgumentOutOfRangeException();
	            }
	        }
	    }

	    public string Title { get; }

	    /* Constructor */

	    public Movie(string title, PriceCodes priceCode)
	    {
	        Title = title;
	        PriceCode = priceCode;
	    }

        public double CalculateAmount(int daysRented)
        {
            return _price.Calculate(daysRented);
        }

	    public int CalculateFrequentRenterPoints(int daysRented)
	    {
	        return _price.CalculateFrequentRenterPoints(daysRented);
	    }
    }
}
