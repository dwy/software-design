namespace CommandLineVideoStore
{
    using NUnit.Framework;

    [TestFixture]
    public class RentalTest
    {
        [Test]
        public void CalculateAmount_MovieTypeRegularDaysRented1_Returns2PointsPerDay()
        {
            var movie = new Movie("any title", "REGULAR", 1);
            const int daysRented = 1;
            var rental = new Rental(movie, daysRented);

            decimal amount = rental.CalculateAmount();

            Assert.AreEqual(2.0m, amount);
        }

        [Test]
        public void CalculateAmount_MovieTypeRegularDaysRented3_ReturnsOnePointFivePointsBonus()
        {
            var movie = new Movie("any title", "REGULAR", 1);
            const int daysRented = 3;
            var rental = new Rental(movie, daysRented);

            decimal amount = rental.CalculateAmount();

            Assert.AreEqual(3.5m, amount);
        }

        [Test]
        public void CalculateAmount_MovieTypeNewRelease_ReturnsThreePointsPerDay()
        {
            var movie = new Movie("any title", "NEW_RELEASE", 1);
            const int daysRented = 1;
            var rental = new Rental(movie, daysRented);

            decimal amount = rental.CalculateAmount();

            Assert.AreEqual(3m, amount);
        }

        [Test]
        public void CalculateAmount_MovieTypeChildrensDaysRentedLessThanThree_ReturnsOnePointFive()
        {
            var movie = new Movie("any title", "CHILDRENS", 1);
            const int daysRented = 1;
            var rental = new Rental(movie, daysRented);

            decimal amount = rental.CalculateAmount();

            Assert.AreEqual(1.5m, amount);
        }

        [Test]
        public void CalculateAmount_MovieTypeChildrensDaysRentedMoreThanThree_ReturnsOnePointFivePerAdditionalDay()
        {
            var movie = new Movie("any title", "CHILDRENS", 1);
            const int daysRented = 4;
            var rental = new Rental(movie, daysRented);

            decimal amount = rental.CalculateAmount();

            Assert.AreEqual(3m, amount);
        }
    }
}