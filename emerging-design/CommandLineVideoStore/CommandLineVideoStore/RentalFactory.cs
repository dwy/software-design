namespace CommandLineVideoStore
{
    public class RentalFactory
    {
        private readonly MoviesRepository _moviesRepository;

        public RentalFactory(MoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public Rental CreateFrom(string input)
        {
            string[] rentalStrings = input.Split(' ');
            var movieNumber = int.Parse(rentalStrings[0]);
            int daysRented = int.Parse(rentalStrings[1]);
            var rentedMovie = _moviesRepository.GetBy(movieNumber);
            return new Rental(rentedMovie, daysRented);
        }
    }
}