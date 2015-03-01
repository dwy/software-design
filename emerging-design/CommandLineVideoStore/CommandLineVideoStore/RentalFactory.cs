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

        public static Rental CreateRental(MovieRepository movieRepository, RentalFactory rentalFactory, string input)
        {
            var rental = rentalFactory.ParseFrom(input);
            rental.Movie = movieRepository.GetMovieBy(rental.MovieNumber);
            return rental;
        }

        public Rental ParseFrom(string input)
        {
            string[] rentalTokens = input.Split(' ');
            return new Rental(Int32.Parse(rentalTokens[0]), Int32.Parse(rentalTokens[1]));
        }
    }
}