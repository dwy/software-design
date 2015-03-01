using System;

namespace CommandLineVideoStore
{
    public class RentalFactory
    {
        private readonly MovieRepository _movieRepository;

        public RentalFactory(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Rental CreateRental(string input)
        {
            string[] rentalTokens = input.Split(' ');
            int movieNumber = Int32.Parse(rentalTokens[0]);
            int daysRented = Int32.Parse(rentalTokens[1]);
            var rental = new Rental(movieNumber, daysRented);
            rental.Movie = _movieRepository.GetMovieBy(rental.MovieNumber);
            return rental;
        }
    }
}