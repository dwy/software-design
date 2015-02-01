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
    }
}