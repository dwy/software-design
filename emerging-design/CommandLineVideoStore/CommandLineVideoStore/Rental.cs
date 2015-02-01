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

        public decimal CalculateAmount()
        {
            decimal amount = 0;
            switch (Movie.Category)
            {
                case "REGULAR":
                    amount += 2;
                    if (DaysRented > 2)
                        amount += (DaysRented - 2) * 1.5m;
                    break;
                case "NEW_RELEASE":
                    amount += DaysRented * 3;
                    break;
                case "CHILDRENS":
                    amount += 1.5m;
                    if (DaysRented > 3)
                        amount += (DaysRented - 3) * 1.5m;
                    break;
            }
            return amount;
        }
    }
}