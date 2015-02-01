namespace CommandLineVideoStore
{
    public class RentalFactory
    {
        private readonly MoviesRepository _moviesRepository;

        public RentalFactory(MoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public Rental CreateRentalFrom(string input)
        {
            string[] rentalStrings = input.Split(' ');
            var number = int.Parse(rentalStrings[0]);
            var rentedMovie = _moviesRepository.GetBy(number);
            int daysRented = int.Parse(rentalStrings[1]);
            return new Rental(rentedMovie, daysRented);
        }
    }
}