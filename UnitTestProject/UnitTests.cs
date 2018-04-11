using System;
using NUnit.Framework;
using StartingPoint;
using StartingPoint.Price;

namespace UnitTestProject
{
    /// <summary>
    /// Unit tests for StartingPoint project.
    /// </summary>
    [TestFixture]
    public class UnitTests
    {
        /* Fields */

        // Movies
        private Movie _cinderella;
        private Movie _starWars;
        private Movie _gladiator;

        // Rentals
        private Rental _rental1;
        private Rental _rental2;
        private Rental _rental3;

        // Customers
        private Customer _mickeyMouse;
        private Customer _donaldDuck;
        private Customer _minnieMouse;

        /* Methods */

        [SetUp]
        public void Init()
        {
            // Create movies
            _cinderella = new Movie("Cinderella", PriceCodes.Childrens);
            _starWars = new Movie("Star Wars", PriceCodes.Regular);
            _gladiator = new Movie("Gladiator", PriceCodes.NewRelease);

            // Create rentals
            _rental1 = new Rental(_cinderella, 5);
            _rental2 = new Rental(_starWars, 5);
            _rental3 = new Rental(_gladiator, 5);

            // Create customers
            _mickeyMouse = new Customer("Mickey Mouse");
            _donaldDuck = new Customer("Donald Duck");
            _minnieMouse = new Customer("Minnie Mouse");
        }

        [TearDown]
        public void TearDown()
        {
            _cinderella = null;
            _starWars = null;
            _gladiator = null;

            // Create rentals
            _rental1 = null;
            _rental2 = null;
            _rental3 = null;

            // Create customers
            _mickeyMouse = null;
            _donaldDuck = null;
            _minnieMouse = null;
        }

        [Test]
        public void TestMovie()
        {
            // Test title property
            Assert.AreEqual("Cinderella", _cinderella.Title);
            Assert.AreEqual("Star Wars", _starWars.Title);
            Assert.AreEqual("Gladiator", _gladiator.Title);

            // Test price code
            Assert.AreEqual(PriceCodes.Childrens, _cinderella.PriceCode);
            Assert.AreEqual(PriceCodes.Regular, _starWars.PriceCode);
            Assert.AreEqual(PriceCodes.NewRelease, _gladiator.PriceCode);
        }

        [Test]
        public void TestRental()
        {
            // Test Movie property
            Assert.AreEqual(_cinderella, _rental1.Movie);
            Assert.AreEqual(_starWars, _rental2.Movie);
            Assert.AreEqual(_gladiator, _rental3.Movie);

            // Test DaysRented property
            Assert.AreEqual(5, _rental1.DaysRented);
            Assert.AreEqual(5, _rental1.DaysRented);
            Assert.AreEqual(5, _rental1.DaysRented);
        }

        [Test]
        public void TestCustomer()
        {
            // Test Name property
            Assert.AreEqual("Mickey Mouse", _mickeyMouse.Name);
            Assert.AreEqual("Donald Duck", _donaldDuck.Name);
            Assert.AreEqual("Minnie Mouse", _minnieMouse.Name);

            // Test AddRental() method - set up for test
            _mickeyMouse.AddRental(_rental1);
            _mickeyMouse.AddRental(_rental2);
            _mickeyMouse.AddRental(_rental3);

            /* At this point, the structure of the program begins getting in the
             * way of testing. Rentals are imbedded in the Customer object, but
             * there is no property to access them. They can only be accessed 
             * internally, by the Statement() method, which imbeds them in the
             * text string passed as it's return value. So, to get these amounts,
             * we will have to parse that value. */

            // Test the Statement() method
            string theResult = _mickeyMouse.Statement();
            // Parse the result
            string[] results = ParseStatementForAssertion(theResult);

            /* The results[] array will have the following elements:
             *		[0] = junk
             *		[1] = junk
             *		[2] = title #1
             *		[3] = price #1
             *		[4] = junk
             *		[5] = title #2
             *		[6] = price #2
             *		[7] = junk
             *		[8] = title #3
             *		[9] = price #3
             *		[10] = "Amount owed is x"
             *		[11] = "You earned x frequent renter points."
             * We will test the title and price elements, and the total 
             * and frequent renter points items. If these tests pass, then 
             * we know that AddRentals() is adding rentals to a Customer 
             * object properly, and that the Statement() method is
             * generating a statement in the expected format. */

            // Test the title and price items
            Assert.AreEqual("Cinderella", results[2]);
            Assert.AreEqual(3, Convert.ToDouble(results[3]));
            Assert.AreEqual("Star Wars", results[5]);
            Assert.AreEqual(6.5, Convert.ToDouble(results[6]));
            Assert.AreEqual("Gladiator", results[8]);
            Assert.AreEqual(15, Convert.ToDouble(results[9]));
        }

        [Test]
        public void TestCustomerWithoutRentals_DoesNotCrash()
        {
            //No extra setup needed

            // Test the Statement() method
            string theResult = _mickeyMouse.Statement();
            // Parse the result
            string[] results = ParseStatementForAssertion(theResult);

            /* The results[] array will have the following elements:
            *		[0] = junk
            *		[1] = "Amount owed is 0"
            *		[2] = "You earned 0 frequent renter points."
            */

            //Assert 
            Assert.AreEqual(results.Length, 3);
        }

        private string[] ParseStatementForAssertion(string statement)
        {
            // Parse the result
            char[] delimiters = "\n\t".ToCharArray();
            string[] results = statement.Split(delimiters);
            return results;
        }
    }
}
