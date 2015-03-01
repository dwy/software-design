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

        public Rental CreateFrom(string input)
        {
            string[] rentalTokens = input.Split(' ');
            int movieNumber = Int32.Parse(rentalTokens[0]);
            int daysRented = Int32.Parse(rentalTokens[1]);
            Movie movie = _movieRepository.GetMovieBy(movieNumber);
            return new Rental(movie, daysRented);
        }
    }
}