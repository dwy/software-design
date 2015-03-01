using System;

namespace CommandLineVideoStore
{
    public class Rental
    {
        private readonly int _movieNumber;
        private readonly int _daysRented;

        public static Rental ParseFrom(String input)
        {
            string[] rentalTokens = input.Split(' ');
            return new Rental(int.Parse(rentalTokens[0]), int.Parse(rentalTokens[1]));
        }

        public Rental(int movieNumber, int daysRented)
        {
            _movieNumber = movieNumber;
            _daysRented = daysRented;
        }

        public int MovieNumber
        {
            get { return _movieNumber; }
        }

        public int DaysRented
        {
            get { return _daysRented; }
        }
    }
}