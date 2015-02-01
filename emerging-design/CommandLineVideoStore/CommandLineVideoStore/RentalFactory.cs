namespace CommandLineVideoStore
{
    public class RentalFactory
    {
        public RentalFactory()
        {
        }

        public Rental CreateRentalFrom(string input, MoviesRepository moviesRepository)
        {
            string[] rentalStrings = input.Split(' ');
            var number = int.Parse(rentalStrings[0]);
            var rentedMovie = moviesRepository.GetBy(number);
            int daysRented = int.Parse(rentalStrings[1]);
            return new Rental(rentedMovie, daysRented);
        }
    }
}