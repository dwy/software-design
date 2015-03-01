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

        public Rental ParseFrom(string input)
        {
            string[] rentalTokens = input.Split(' ');
            return new Rental(int.Parse(rentalTokens[0]), int.Parse(rentalTokens[1]));
        }
    }
}