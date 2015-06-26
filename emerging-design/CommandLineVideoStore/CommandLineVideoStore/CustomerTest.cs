namespace CommandLineVideoStore
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class CustomerTest
    {
        [Test]
        public void FrequentRenterPoints_NoRental_ReturnsZeroPoints()
        {
            var rentals = new List<Rental>();
            var customer = new Customer("any name", rentals);

            Assert.AreEqual(0, customer.FrequentRenterPoints);
        }

        [Test]
        public void FrequentRenterPoints_OneRegularRental_ReturnsOnePoint()
        {
            var movie = new Movie("any title", "REGULAR", 1);
            const int daysRented = 1;
            var rentals = new List<Rental> { new Rental(movie, daysRented) };
            var customer = new Customer("any name", rentals);

            Assert.AreEqual(1, customer.FrequentRenterPoints);
        }

        [Test]
        public void FrequentRenterPoints_OneNewRentalForOneDay_ReturnsTwoPoints()
        {
            var movie = new Movie("any title", "NEW_RELEASE", 1);
            const int daysRented = 2;
            var rentals = new List<Rental> { new Rental(movie, daysRented) };
            var customer = new Customer("any name", rentals);

            Assert.AreEqual(2, customer.FrequentRenterPoints);
        }
    }
}