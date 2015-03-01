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

        public Rental CreateRental(MovieRepository movieRepository, string input)
        {
            var rental = ParseFrom(input);
            rental.Movie = movieRepository.GetMovieBy(rental.MovieNumber);
            return rental;
        }

        private Rental ParseFrom(string input)
        {
            string[] rentalTokens = input.Split(' ');
            return new Rental(Int32.Parse(rentalTokens[0]), Int32.Parse(rentalTokens[1]));
        }
    }
}