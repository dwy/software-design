namespace CommandLineVideoStore
{
    public class Rental
    {
        private readonly Movie _rentedMovie;
        private readonly int _daysRented;

        public Rental(Movie rentedMovie, int daysRented)
        {
            _rentedMovie = rentedMovie;
            _daysRented = daysRented;
        }

        public Movie Movie
        {
            get { return _rentedMovie; }
        }

        public int DaysRented
        {
            get { return _daysRented; }
        }

        public static decimal CalculateRentalAmount(Rental rental)
        {
            decimal thisAmount = 0;
            switch (rental.Movie.Category)
            {
                case "REGULAR":
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                        thisAmount += (rental.DaysRented - 2)*1.5m;
                    break;
                case "NEW_RELEASE":
                    thisAmount += rental.DaysRented*3;
                    break;
                case "CHILDRENS":
                    thisAmount += 1.5m;
                    if (rental.DaysRented > 3)
                        thisAmount += (rental.DaysRented - 3)*1.5m;
                    break;
            }
            return thisAmount;
        }
    }
}