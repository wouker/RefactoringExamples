using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartingPoint
{
	/// <summary>
	/// Customer represents a customer of the store.
	/// </summary>
	public class Customer
	{
		/* Fields */
		
		private readonly List<Rental>  _rentals = new List<Rental>();

		/* Constructor */
		public Customer(string name)
		{
			Name = name;
		}

		/* Properties */

		public string Name { get; }

        /*
         * Totals are extra iteration in Statement. But logic from Martin Fowler:
            These queries are now available for any code written in the customer class. They can easily be
            added to the interface of the class should other parts of the system need this information. Without
            queries like these, other methods have to deal with knowing about the rentals and building the
            loops. In a complex system, that will lead to much more code to write and maintain.
         */

        public double TotalAmount
        {
            get { return _rentals.Sum(r => r.CalculateAmount()); }
        }

	    public double TotalFrequentRenterPoints
	    {
	        get { return _rentals.Sum(r => r.CalculateFrequentRenterPoints()); }
	    }

	    /* Methods */

		public void AddRental(Rental arg)
		{
			_rentals.Add(arg);
		}

		public string Statement()
		{
		    var sb = new StringBuilder();
			sb.AppendLine($"Rental record for {Name}");
		    foreach (var rental in _rentals)
		    {
		        var thisAmount = rental.CalculateAmount();
                // Show figures for this rental
		        sb.AppendLine($"\t{rental.Movie.Title}\t{thisAmount}");
			}

            // Add footer lines
		    sb.AppendLine($"Amount owed is {TotalAmount}");
		    sb.Append($"You earned {TotalFrequentRenterPoints} frequent renter points.");
			return sb.ToString();
		}
	}
}
